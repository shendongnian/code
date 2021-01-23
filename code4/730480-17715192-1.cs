        public static List<string> GetFileList(NetworkCredential credential, string FTPSite, string FTPFolder, string extension)
        {
            List<string> files = new List<string>();
            int retries = 0;
            int maxRetries = 5;
            bool downloaded = false;
            string LSOutput = "";
            while (!downloaded && retries < maxRetries)
            {
                try
                {
                    LSOutput = "";
                    //Fetch LS
                    FtpWebRequest request = (FtpWebRequest) WebRequest.Create(@"ftp://" + FTPSite + FTPFolder);
                    request.Credentials = credential;
                    request.UseBinary = true;
                    request.EnableSsl = true;
                    request.Method = WebRequestMethods.Ftp.ListDirectory;
                    FtpWebResponse response = null;
                    response = (FtpWebResponse) request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
                    LSOutput = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    PrepareLog("LS output while finding files:");
                    PrepareLog(LSOutput);
                    downloaded = true;
                }
                catch (Exception ex)
                {
                    retries++;
                }
            }
            if (downloaded)
            {
                //Parse the LS
                string[] LSOutputLines = LSOutput.Trim().Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string LSOutputLine in LSOutputLines)
                    files.Add(LSOutputLine);
                //Filter files
                files = files.Where(f => f.ToLower().EndsWith(extension.ToLower())).ToList();
                PrepareLogAndEmail("Total " + extension.ToLower() + " files found: " + files.Count, LogMessageType.Simple);
                return files;
            }
            else
            {
                PrepareLogAndEmail("Failed to download file", LogMessageType.Simple);
                return null;
            }
        }
