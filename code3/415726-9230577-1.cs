            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(uri);
            ftpRequest.Credentials = new NetworkCredential("anonymous","yourName@SomeDomain.com");//replace with your Creds
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            List<string> directories = new List<string>();
            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                directories.Add(line);
                line = streamReader.ReadLine();
            }
            
            streamReader.Close();
            // also add some code that will Dispose of the StreamReader object
            // something like ((IDisposable)streanReader).Dispose();
            // Dispose of the List<string> as well 
               line = null;
             
