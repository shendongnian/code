    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System.Net;
    using System.IO;
    namespace ConsoleApplication26
    {
        class Program
        {
            static void Main(string[] args)
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.DevelopmentStorageAccount;
                CloudBlobContainer blobContainer = storageAccount.CreateCloudBlobClient().GetContainerReference("temp");
                //Create blob container.
                blobContainer.CreateIfNotExists();
                string blobContents = "Let's test SAS out :)";
                byte[] bytes = Encoding.UTF8.GetBytes(blobContents);
    
                string blobName = "sastest.txt";
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference(blobName);
                //Upload blob
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    blob.UploadFromStream(ms);
                }
                //Get SAS Uri
                var sasUri = GetSasUrl(blobContainer, blobName);
                DownloadBlob(sasUri);
    
                Console.ReadLine();
    
            }
    
            static Uri GetSasUrl(CloudBlobContainer blobContainer, string blobName)
            {
                var policy = new SharedAccessBlobPolicy()
                {
                    SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5),
                    SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(5),
                    Permissions = SharedAccessBlobPermissions.Read,
                };
    
                var sas = blobContainer.GetSharedAccessSignature(policy);
                return new Uri(string.Format("{0}/{1}{2}", blobContainer.Uri, blobName, sas));
            }
    
            static void DownloadBlob(Uri sasUri)
            {
                var request = (HttpWebRequest)WebRequest.Create(sasUri);
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    long responseContentLength = response.ContentLength;
                    byte[] fetchedContents = new byte[(int) responseContentLength];
                    using (var stream = response.GetResponseStream())
                    {
                        stream.Read(fetchedContents, 0, fetchedContents.Length);
                    }
                    string blobContents = Encoding.UTF8.GetString(fetchedContents);
                    Console.WriteLine("Blob Contents: " + blobContents);
                }
            }
        }
    }
    
