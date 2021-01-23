    var credentials = new SharePointOnlineCredentials(userName, securePassword);
    AddAttachmentFile(webUrl, credentials, "Nokia Offices", 1, @"c:\upload\Nokia Head Office in Espoo.jpg");
    public static void AddAttachmentFile(string webUrl,ICredentials credentials,string listTitle,int itemId,string filePath)
    {
            using (var client = new SPWebClient(new Uri(webUrl),credentials))
            {
                var fileContent = System.IO.File.ReadAllBytes(filePath);
                var fileName = System.IO.Path.GetFileName(filePath);
                var endpointUrl = string.Format("{0}/_api/web/lists/GetByTitle('{1}')/items({2})/AttachmentFiles/add(FileName='{3}')", webUrl,listTitle,itemId,fileName);
                client.UploadFile(new Uri(endpointUrl), fileContent);
            }
    }
