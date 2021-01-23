    class MyFtpClient
    {
        protected string FtpUser { get; set; }
        protected string FtpPass { get; set; }
        protected string FtpServerUrl { get; set; }
        protected string DirPathToUpload { get; set; }
        protected string BaseDirectory { get; set; }
        public MyFtpClient(string ftpuser, string ftppass, string ftpserverurl, string dirpathtoupload)
        {
            this.FtpPass = ftppass;
            this.FtpUser = ftpuser;
            this.FtpServerUrl = ftpserverurl;
            this.DirPathToUpload = dirpathtoupload;
            var spllitedpath = dirpathtoupload.Split('\\').ToArray();
            // last index must be the "base" directory on the server
            this.BaseDirectory = spllitedpath[spllitedpath.Length - 1];
        }
    
    
        public void UploadDirectory()
        {
            // rename the old folder version (if exist)
            RenameDir(BaseDirectory);
            // create a parent folder on server
            CreateDir(BaseDirectory);
            // upload the files in the most external directory of the path
            UploadAllFolderFiles(DirPathToUpload, BaseDirectory);
            // loop trough all files in subdirectories
    
    
    
            foreach (string dirPath in Directory.GetDirectories(DirPathToUpload, "*",
            SearchOption.AllDirectories))
            {
                // create the folder
                CreateDir(dirPath.Substring(dirPath.IndexOf(BaseDirectory), dirPath.Length - dirPath.IndexOf(BaseDirectory)));
    
                Console.WriteLine(dirPath.Substring(dirPath.IndexOf(BaseDirectory), dirPath.Length - dirPath.IndexOf(BaseDirectory)));
                UploadAllFolderFiles(dirPath, dirPath.Substring(dirPath.IndexOf(BaseDirectory), dirPath.Length - dirPath.IndexOf(BaseDirectory))
            }
        }
    
        private void UploadAllFolderFiles(string localpath, string remotepath)
        {
            string[] files = Directory.GetFiles(localpath);
            // get only the filenames and concat to remote path
            foreach (string file in files)
            {
                // full remote path
                var fullremotepath = remotepath + "\\" + Path.GetFileName(file);
                // local path
                var fulllocalpath = Path.GetFullPath(file);
                // upload to server
                Upload(fulllocalpath, fullremotepath);
            }
    
        }
    
        public bool CreateDir(string dirname)
        {
            try
            {
                WebRequest request = WebRequest.Create("ftp://" + FtpServerUrl + "/" + dirname);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Proxy = new WebProxy();
                request.Credentials = new NetworkCredential(FtpUser, FtpPass);
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    if (resp.StatusCode == FtpStatusCode.PathnameCreated)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
    
            catch
            {
                return false;
            }
        }
    
        public void Upload(string filepath, string targetpath)
        {
    
            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(FtpUser, FtpPass);
                client.Proxy = null;
                var fixedpath = targetpath.Replace(@"\", "/");
                client.UploadFile("ftp://" + FtpServerUrl + "/" + fixedpath, WebRequestMethods.Ftp.UploadFile, filepath);
            }
        }
    
        public bool RenameDir(string dirname)
        {
            var path = "ftp://" + FtpServerUrl + "/" + dirname;
            string serverUri = path;
    
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
                request.Method = WebRequestMethods.Ftp.Rename;
                request.Proxy = null;
                request.Credentials = new NetworkCredential(FtpUser, FtpPass);
                // change the name of the old folder the old folder
                request.RenameTo = DateTime.Now.ToString("yyyyMMddHHmmss"); 
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    if (resp.StatusCode == FtpStatusCode.FileActionOK)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
