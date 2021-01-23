    string IP = "192.168.1.1", User = "Testuser", Pass = "123";
    SftpClient sftp;
    private void UploadFileSFTP()
        {
            sftp = new SftpClient(IP, User, Pass);
            sftp.Connect();
            Uploader();
            Downloader();
            sftp.Disconnect();
        }
    string FilePath="C:\\folder\\", Filename = "Filename.extention", 
           DeliveryPath = "/tmp/";
    private void Uploader()
        {
            using (var file = File.OpenRead(FilePath + Filename))
            {
                sftp.UploadFile(file, DeliveryPath + Filename);
            }
        }
    //there is possibly a simpler way to download but this is how i did it.
    string FromPath = "/tmp/testfile.txt", StoragePath = ""; 
    private void Downloader()
        {
            if (File.Exists(StoragePath))
                File.Delete(StoragePath);
            if (!Directory.GetDirectories(Path.GetTempPath()).Contains("WorkFiles"))
            {
                Directory.CreateDirectory(Path.GetTempPath() + "WorkFiles");
            }
            
            StoragePath = Path.GetTempPath() + "WorkFiles\\testFile.txt";
            Int64 iSize = sftp.ReadAllBytes(FromPath).Length;
            Int64 iRunningByteTotal = 0;
            using (Stream streamRemote = sftp.OpenRead(FromPath))
            {
                using (Stream streamLocal = new FileStream(StoragePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    int iByteSize = 0;
                    byte[] byteBuffer = new byte[iSize];
                    while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                    {
                        streamLocal.Write(byteBuffer, 0, iByteSize);
                        iRunningByteTotal += iByteSize;
                    }
                }
            }
        }
