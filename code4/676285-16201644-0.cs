    private void getFiles () {
        string startupPath = Application.StartupPath;
        /*
         * This finds the files within the users installation folder
         */
        string[] files = Directory.GetFiles(startupPath + "\\App_Data", "*.*",
            SearchOption.AllDirectories);
        using (WebClient client = new WebClient())
        {
            int downloadCount = 0;
            client.DownloadDataCompleted += 
                new DownloadDataCompletedEventHandler((o, e) => 
                {
                        downloadCount--;
                });
            foreach (string s in files)
            {
                /*
                 * This gets the file name
                 */
                string fileName = Path.GetFileName(s);
                /*
                 * This gets the folder and subfolders after the main directory
                 */
                string filePath = s.Substring(s.IndexOf("App_Data"));
                downloadFile(client, "user:pass@mysite.tk/updates/App_Data/" + fileName,
                startupPath + "\\" + filePath);
                downloadCount++;
            }
            while (downloadCount > 0) { }
        }
    }
    private void downloadFile (WebClient client, string urlAddress, string location)
    {
        System.Uri URL = new System.Uri("ftp://" + urlAddress);
        client.DownloadFileAsync(URL, location);
    }
