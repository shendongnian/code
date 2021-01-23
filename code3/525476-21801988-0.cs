        static void Main(string[] args)
        {
            var client = new SkyDriveServiceClient();
            client.LogOn("YourEmail@hotmail.com", "password");
            WebFolderInfo wfInfo = new WebFolderInfo();
            WebFolderInfo[] wfInfoArray = client.ListRootWebFolders();
            wfInfo = wfInfoArray[0];
            client.Timeout = 1000000000;
            string fn = @"test.txt";
            if (File.Exists(fn))
            {
                client.UploadWebFile(fn, wfInfo);
            }
  
        }
