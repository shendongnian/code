    string _remoteHost = "ftp://ftp.site.com/htdocs/directory/";
        string _remoteUser = "site.com";
        string _remotePass = "password";
        string sourcePath = @"C:\";
        public void uploadFile(string name)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_remoteHost +name+ ".txt");
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(_remoteUser, _remotePass);
            StreamReader sourceStream = new StreamReader(sourcePath + name+ ".txt");
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            response.Close();
        }
