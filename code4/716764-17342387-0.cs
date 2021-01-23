        void CheckNumberOfUses()
        {
            // Get the objects used to communicate with the server.
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://mywebsite.xx/public_html/something1/something2/myfile.txt");
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("http://mywebsite.xx/something1/something2/myfile.txt");
            StringBuilder sb = new StringBuilder();
            byte[] buf = new byte[8192];
            HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
            Stream resStream = response.GetResponseStream();
            string tempString = null;
            int count = resStream.Read(buf, 0, buf.Length);
            if (count != 0)
            {
                tempString = Encoding.ASCII.GetString(buf, 0, count);
                int numberOfUses = int.Parse(tempString) + 1;
                sb.Append(numberOfUses);
            }
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
            // This example assumes the FTP site uses anonymous logon.
            ftpRequest.Credentials = new NetworkCredential("login", "password");
            // Copy the contents of the file to the request stream.
            byte[] fileContents = Encoding.UTF8.GetBytes(sb.ToString());
            ftpRequest.ContentLength = fileContents.Length;
            Stream requestStream = ftpRequest.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            ftpResponse.Close();
        }    
