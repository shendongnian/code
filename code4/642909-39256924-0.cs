    private void UploadProfileImage(string TargetFileName, string TargetDestinationPath, string FiletoUpload)
            {
                //Get the Image Destination path
                string imageName = TargetFileName; 
                string imgPath = TargetDestinationPath; 
    
                string ftpurl = "ftp://downloads.abc.com/downloads.abc.com/MobileApps/SystemImages/ProfileImages/" + imgPath;
                string ftpusername = krayknot_DAL.clsGlobal.FTPUsername;
                string ftppassword = krayknot_DAL.clsGlobal.FTPPassword;
                string fileurl = FiletoUpload;
    
                FtpWebRequest ftpClient = (FtpWebRequest)FtpWebRequest.Create(ftpurl);
                ftpClient.Credentials = new System.Net.NetworkCredential(ftpusername, ftppassword);
                ftpClient.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
                ftpClient.UseBinary = true;
                ftpClient.KeepAlive = true;
                System.IO.FileInfo fi = new System.IO.FileInfo(fileurl);
                ftpClient.ContentLength = fi.Length;
                byte[] buffer = new byte[4097];
                int bytes = 0;
                int total_bytes = (int)fi.Length;
                System.IO.FileStream fs = fi.OpenRead();
                System.IO.Stream rs = ftpClient.GetRequestStream();
                while (total_bytes > 0)
                {
                    bytes = fs.Read(buffer, 0, buffer.Length);
                    rs.Write(buffer, 0, bytes);
                    total_bytes = total_bytes - bytes;
                }
                //fs.Flush();
                fs.Close();
                rs.Close();
                FtpWebResponse uploadResponse = (FtpWebResponse)ftpClient.GetResponse();
                string value = uploadResponse.StatusDescription;
                uploadResponse.Close();
            }
