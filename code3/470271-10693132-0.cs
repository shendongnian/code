        private string SharePointSite
        {
            get { return @"https://Mysite.com/My Document Library"; }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                CreateFolder("Test " + i.ToString());
            }
        }
        private bool CreateFolder(string FolderName)
        {
            string folderURL = SharePointSite + @"/" + FolderName;
            bool _Return = false;
            try
            {
                WebRequest request = WebRequest.Create(folderURL);
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = "MKCOL";
                WebResponse response = request.GetResponse();
                response.Close();
                _Return = true;
            }
            catch (WebException)
            {
                _Return = false;
            }
            Console.WriteLine("{0} Created {1}", FolderName, _Return);
            return _Return;
        }
