    public static void DownloadFilesFromFTP(string localFilesPath, string remoteFTPPath)
            {
                using (var sftp = new SftpClient(Settings.Default.FTPHost, Settings.Default.FTPUsername, Settings.Default.FTPPassword))
                {
                    sftp.Connect();
                    sftp.ChangeDirectory(remoteFTPPath);
                    var ftpFiles = sftp.ListDirectory(remoteFTPPath, null);
                    StringBuilder filePath = new StringBuilder();
                    foreach (var fileName in ftpFiles)
                    {
    
                        filePath.Append(localFilesPath).Append(fileName.Name);
                        string e = Path.GetExtension(filePath.ToString());
                        if (e == ".csv")
                        {
                            using (var file = File.OpenWrite(filePath.ToString()))
                            {
                                sftp.DownloadFile(fileName.FullName, file, null);
                                sftp.Delete(fileName.FullName);
                            }
                        }
                        filePath.Clear();
                    }
                    sftp.Disconnect();
                }
            }
