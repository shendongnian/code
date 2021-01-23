     WebClient client = null;
            public FileDownloader()
            {
                InitializeComponent();
                client = new WebClient();
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;
            }
    
            void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
            {
                lblMessage.Text = "File Download Compeleted.";
            }
    
            void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                lblMessage.Text = e.ProgressPercentage + " % Downloaded.";
            }
    
            private void StartDownload(object sender, RoutedEventArgs e)
            {
                if (client == null)
                    client = new WebClient();
    
    //Loop thru your files for eg. file1.dll, file2.dll .......etc.
                for (int index = 0; index < 10; index++)
                {
                    //loop on files 
                    client.DownloadFileAsync(
                        new Uri(
                                @"http://mywebsite.com/Files/File" + index.ToString() + ".dll"
                                , UriKind.RelativeOrAbsolute),
                        @"C:\Temp\file+" + index.ToString() + ".dll");
                }
    
            }
