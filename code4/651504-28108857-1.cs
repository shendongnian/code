    public void UploadFile(RemoteFileInfo request)
            {   
                string filePath = string.Empty;
                string guid = Guid.NewGuid().ToString();
                int chunkSize = 1024;
                byte[] buffer = new byte[chunkSize];
                long progress = 0;
    
                filePath = Path.Combine(uploadFolder, request.FileName);
    
                if (File.Exists(filePath))
                    File.Delete(filePath);
    
                using (FileStream writeStream = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
                {
              do
                    {
                        // read bytes from input stream
                        int bytesRead = request.FileByteStream.Read(buffer, 0, chunkSize);
                        if (bytesRead == 0)
                            break;
                        progress += bytesRead;                    
                        // write bytes to output stream
                        writeStream.Write(buffer, 0, bytesRead);
                    }
                    while (true);
                }
            }
