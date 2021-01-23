        public void UploadImageToftp()
    
            {
    
         string server = "ftp://111.61.28.128/Example/"; //server path
         string name = @"E:\Apache\htdocs\visa\image.png"; //image path
          string Imagename= Path.GetFileName(name);
    
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}{1}", server, Imagename)));
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.Credentials = new NetworkCredential("username", "password");
        Stream ftpStream = request.GetRequestStream();
        FileStream fs = File.OpenRead(name);
        byte[] buffer = new byte[1024];
        int byteRead = 0;
        do
        {
            byteRead = fs.Read(buffer, 0, 1024);
            ftpStream.Write(buffer, 0, byteRead);
        }
        while (byteRead != 0);
        fs.Close();
        ftpStream.Close();
        MessageBox.Show("Image Upload successfully!!");
    }
