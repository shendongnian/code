    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Configuration;
    using System.Web;
    using System.Linq;
    using System.IO;
    using Umbraco.Core;
    using Umbraco.Core.Events;
    using Umbraco.Core.Models;
    using Umbraco.Core.Services;
    
    namespace utest1.umbracoExtensions.events
    {
        public class SaveMediaToAzure : ApplicationEventHandler
        {
            /* either add your own logging class or remove this and all calls to 'log' */
            private log4net.ILog log = log4net.LogManager.GetLogger(typeof(utest1.logging.PublicLogger));
            
            CloudStorageAccount storageAccount;
            private string blobContainerName;
            CloudBlobClient blobClient;
            CloudBlobContainer container;
            string cacheControlHeader;
            
            private bool uploadEnabled;
    
            public SaveMediaToAzure()
            {
                try
                {
                    storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["AzureCDNStorageConnectionString"]);
                    blobContainerName = ConfigurationManager.AppSettings["AzureCDNStorageAccountName"];
                    blobClient = storageAccount.CreateCloudBlobClient();
                    container = blobClient.GetContainerReference(ConfigurationManager.AppSettings["AzureCDNBlobContainerName"]);
                    uploadEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["AzureCDNUploadEnabled"]);
                    cacheControlHeader = ConfigurationManager.AppSettings["AzureCDNCacheControlHeader"];
                    
                    MediaService.Saved += MediaServiceSaved;
                    MediaService.Trashed += MediaServiceTrashed;
                    MediaService.Deleted += MediaServiceDeleted; // not firing
                }
                catch (Exception x)
                {
                    log.Error("SaveMediaToAzure Config Error", x);
                }
            }
    
            void MediaServiceSaved(IMediaService sender, SaveEventArgs<IMedia> e)
            {
                if (uploadEnabled)
                {
                    foreach (var fileItem in e.SavedEntities)
                    {
                        try
                        {
                            log.Info("Saving media to Azure:" + e.SavedEntities.First().Name);
                            var path = fileItem.GetValue("umbracoFile").ToString();
                            var filePath = HttpContext.Current.Server.MapPath(path);
    
                            UploadToAzure(filePath, path);
                            
                            if (fileItem.GetType() == typeof(Umbraco.Core.Models.Media))
                            {
                                UploadThumbToAzure(filePath, path);
                            }
                        }
                        catch (Exception x)
                        {
                            log.Error("Error saving media to Azure: " + fileItem.Name, x);
                        }
                    }
                }
            }
    
            /*
             * Using this because MediaServiceDeleted event is not firing in v6.1.6
             * 
             */
    
            void MediaServiceTrashed(IMediaService sender, MoveEventArgs<IMedia> e)
            {
                if (uploadEnabled)
                {
                    try
                    {
                        log.Info("Deleting media from Azure:" + e.Entity.Name);
                        var path = e.Entity.GetValue("umbracoFile").ToString();
                        CloudBlockBlob imageBlob = container.GetBlockBlobReference(StripContainerNameFromPath(path));
                        imageBlob.Delete();
                        CloudBlockBlob thumbBlob = container.GetBlockBlobReference(StripContainerNameFromPath(GetThumbPath(path)));
                        thumbBlob.Delete();
    
                    }
                    catch (Exception x)
                    {
                        log.Error("Error deleting media from Azure: " + e.Entity.Name, x);
                    }
                }
    
            }
    
            /*
             * MediaServiceDeleted event not firing in v6.1.6
             * 
             */
    
            void MediaServiceDeleted(IMediaService sender, DeleteEventArgs<IMedia> e)
            {
                //if (uploadEnabled)
                //{
                //    try
                //    {
                //        log.Info("Deleting media from Azure:" + e.DeletedEntities.First().Name);
                //        var path = e.DeletedEntities.First().GetValue("umbracoFile").ToString();
                //        CloudBlockBlob imageBlob = container.GetBlockBlobReference(StripContainerNameFromPath(path));
                //        imageBlob.Delete();
                //        CloudBlockBlob thumbBlob = container.GetBlockBlobReference(StripContainerNameFromPath(GetThumbPath(path)));
                //        thumbBlob.Delete();
                //    }
                //    catch (Exception x)
                //    {
                //        log.Error("Error deleting media from Azure: " + e.DeletedEntities.First().Name, x);
                //    }
                //}
    
                Console.WriteLine(e.DeletedEntities.First().Name);  // still not working
    
            }
    
            private string StripContainerNameFromPath(string path)
            {
                return path.Replace("/media/", String.Empty);
            }
    
            /*
             * 
             * 
             */
    
            private void UploadToAzure(string filePath, string relativePath)
            {
                System.IO.MemoryStream data = new System.IO.MemoryStream();
                System.IO.Stream str = System.IO.File.OpenRead(filePath);
    
                str.CopyTo(data);
                data.Seek(0, SeekOrigin.Begin);
                byte[] buf = new byte[data.Length];
                data.Read(buf, 0, buf.Length);
    
                Stream stream = data as Stream;
    
                if (stream.CanSeek)
                {
                    stream.Position = 0;
                    CloudBlockBlob blob = container.GetBlockBlobReference(StripContainerNameFromPath(relativePath));
                    blob.UploadFromStream(stream);
                    SetCacheControl(blob);
                }
                else
                {
                    log.Error("Could not read image for upload: " + relativePath);
                }
            }
    
            private void SetCacheControl(CloudBlockBlob blob)
            {
                blob.Properties.CacheControl = cacheControlHeader;
                blob.SetProperties();
            }
    
            private void UploadThumbToAzure(string filePath, string relativePath)
            {
                var parts = filePath.Split('.');
                var filename = parts[parts.Length - 2];
                var thumbFilePath = GetThumbPath(filePath);
                var thumbRelativePath = GetThumbPath(relativePath);
                UploadToAzure(thumbFilePath, thumbRelativePath);
            }
    
            private string GetThumbPath(string path)
            {
                var parts = path.Split('.');
                var filename = parts[parts.Length - 2];
                return path.Replace(filename, filename + "_thumb");
            }
    
        }
    }
