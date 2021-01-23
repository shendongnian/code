            var client = new SkyDriveServiceClient();
            client.LogOn("username", "password");        
            WebFolderInfo wfInfo = new WebFolderInfo();
                      
            WebFolderInfo[] wfInfo = client.ListRootWebFolders();
            
            wfInfo = wfInfo[0];
            
            client.UploadWebFile(@"D:\db.bak", wfInfo);
