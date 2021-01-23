    public void Download(object sender, DoWorkEventArgs e)
            {
                List<File> driveFiles = Google.Apis.Util.Utilities.RetrieveAllFiles(service);
                int fileCount = driveFiles.Count;
                int i = 0;
                IAuthenticator authenticator = new CloudManager().CreateAuthentication();
                foreach (var driveFile in driveFiles.Where(driveFile => driveFile.MimeType != "video/mp4"))
                {
                    LabelFileProcess.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                                                            (Action) (() => LabelFileProcess.Content = driveFile.Title));
                    string title = driveFile.Title;
                    LabelFileProcess.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                                            (Action) (() => LabelFileProcess.Content = title));
                    if (string.IsNullOrEmpty(driveFile.Title))
                    {
                        MessageBox.Show(@"File's title is emplty");
                        continue;
                    }
    
                    if (driveFile.MimeType != "application/vnd.google-apps.folder")
                    {
    
                        Stream stream = Utilities.DownloadFile(authenticator, driveFile);
                        if (stream != null)
                            Utilities.SaveFile(stream, driveFile.Title);
                    }
                    else
                        Directory.CreateDirectory("D:\\GdriveFiles\\" + driveFile.Title);
                }
