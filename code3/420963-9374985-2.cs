            var client = new SkyDriveServiceClient();
            client.LogOn("username", "password");        
            WebFolderInfo wfInfo = new WebFolderInfo();
                      
            WebFolderInfo[] wfInfoArray = client.ListRootWebFolders();
            
            wfInfo = wfInfoArray[0];
            client.Timeout = 1000000000;
            client.UploadWebFile(@"D:\db.bak", wfInfo);
