    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using Microsoft.SharePoint.Client;
    using System.Security;
    
    using ClientOM = Microsoft.SharePoint.Client;
    
    namespace MvcApplication.Models.Home
    {
        public class SharepointModel
        {
            public ClientContext clientContext { get; set; }
            private string ServerSiteUrl = "https://somecompany.sharepoint.com/sites/ITVillahermosa";
            private string LibraryUrl = "Shared Documents/Invoices/";
            private string UserName = "israel.delacruz@somecompany.com";
            private string Password = "********";
            private Web WebClient { get; set; }
    
            public SharepointModel()
            {
                this.Connect();
            }
    
            public void Connect()
            {
                try
                {
                    using (clientContext = new ClientContext(ServerSiteUrl))
                    {
                        var securePassword = new SecureString();
                        foreach (char c in Password)
                        {
                            securePassword.AppendChar(c);
                        }
    
                        clientContext.Credentials = new SharePointOnlineCredentials(UserName, securePassword);
                        WebClient = clientContext.Web;
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
    
            public string UploadMultiFiles(HttpRequestBase Request, HttpServerUtilityBase Server)
            {
                try
                {
                    HttpPostedFileBase file = null;
                    for (int f = 0; f < Request.Files.Count; f++)
                    {
                        file = Request.Files[f] as HttpPostedFileBase;
    
                        string[] SubFolders = LibraryUrl.Split('/');
                        string filename = System.IO.Path.GetFileName(file.FileName);
                        var path = System.IO.Path.Combine(Server.MapPath("~/App_Data/uploads"), filename);
                        file.SaveAs(path);
    
                        clientContext.Load(WebClient, website => website.Lists, website => website.ServerRelativeUrl);
                        clientContext.ExecuteQuery();
    
                        //https://qmaxsolutions.sharepoint.com/sites/ITVillahermosa/Shared Documents/
                        List documentsList = clientContext.Web.Lists.GetByTitle("Documents"); //Shared Documents -> Documents
                        clientContext.Load(documentsList, i => i.RootFolder.Folders, i => i.RootFolder);
                        clientContext.ExecuteQuery();
    
                        string SubFolderName = SubFolders[1];//Get SubFolder 'Invoice'
                        var folderToBindTo = documentsList.RootFolder.Folders;
                        var folderToUpload = folderToBindTo.Where(i => i.Name == SubFolderName).First();
    
                        var fileCreationInformation = new FileCreationInformation();
                        //Assign to content byte[] i.e. documentStream
                        fileCreationInformation.Content = System.IO.File.ReadAllBytes(path);
                        //Allow owerwrite of document
                        fileCreationInformation.Overwrite = true;
                        //Upload URL
                        fileCreationInformation.Url = ServerSiteUrl + LibraryUrl + filename;
    
                        Microsoft.SharePoint.Client.File uploadFile = documentsList.RootFolder.Files.Add(fileCreationInformation);
    
                        //Update the metadata for a field having name "DocType"
                        uploadFile.ListItemAllFields["Title"] = "UploadedCSOM";
    
                        uploadFile.ListItemAllFields.Update();
                        clientContext.ExecuteQuery();
                    }
    
                    return "";
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
    
            public string DownloadFiles()
            {
                try
                {
                    string tempLocation = @"c:\Downloads\Sharepoint\";
                    System.IO.DirectoryInfo di = new DirectoryInfo(tempLocation);
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
    
                    FileCollection files = WebClient.GetFolderByServerRelativeUrl(this.LibraryUrl).Files;
                    clientContext.Load(files);
                    clientContext.ExecuteQuery();
    
                    if (clientContext.HasPendingRequest)
                        clientContext.ExecuteQuery();
    
                    foreach (ClientOM.File file in files)
                    {
                        FileInformation fileInfo = ClientOM.File.OpenBinaryDirect(clientContext, file.ServerRelativeUrl);
                        clientContext.ExecuteQuery();
    
                        var filePath = tempLocation + file.Name;
                        using (var fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                        {
                            fileInfo.Stream.CopyTo(fileStream);
                        }
                    }
    
                    return "";
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
    
        }
    }
