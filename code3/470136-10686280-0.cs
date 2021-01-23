     public void addToSharepointImageList(string folderName, string fileName, byte[] content)
        {
            string path = @"\\yoursite\yourlistname\";
            string baseSharePointPath = "http://yoursite/";
            string listName = "yourlistname"; 
            SharePointImagingService.Imaging svc = null;
            try
            {
                path += folderName;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                #region create sharepoint service
                svc = new SharePointImagingService.Imaging();
                NetworkCredential nc = new NetworkCredential("username", "password", "domain");
                svc.Credentials = nc;
                //svc.Credentials = System.Net.CredentialCache.DefaultCredentials;
                svc.Url = baseSharePointPath + listName+ "/_vti_bin/imaging.asmx";
                svc.Discover();
                #endregion
                svc.Upload(baseSharePointPath + listName, folderName, content, fileName, true);
            }
            catch (Exception e)
            {
                //deal with error
            }
            finally
            {
                svc.Dispose();
            }
        }
