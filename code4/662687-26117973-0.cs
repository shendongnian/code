    private void FTPUPLOAD(string imgPath)
            {
                FTPDelete(img);
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(BaseUrl +Path.GetFileName(imgPath));
                request.Method = WebRequestMethods.Ftp.UploadFile;
    
                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(Account, Password);
    
                // Copy the contents of the file to the request stream.
                 //THIS IS THE CODE
                byte[] fileContents = File.ReadAllBytes(imgPath);
               
     Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();
    
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    
                response.Close();
            }
