    Digitalez.DirectoryUtil.EnsureDirectoryExists(relativePath);
            string filePath = System.IO.Path.Combine(relativePath, fileInfo.Name);
            long length = Digitalez.FtpUtil.GetFileLength(fileInfo.FullPath, userName, password, usePassive);
            long offset = 0;
            int retryCount = 10;
            int? readTimeout = 5 * 60 * 1000; //five minutes
            // if the file exists, do not download it
            if (System.IO.File.Exists(filePath))
            {
              return false;
            }
            while (retryCount > 0)
            {
              using (System.IO.Stream responseStream = Captator.Eifos.Net.FtpUtil.GetFileAsStream(fileInfo.FullPath, userName, password, usePassive, offset, requestTimeout: readTimeout != null ? readTimeout.Value : System.Threading.Timeout.Infinite))
              {
                using (System.IO.FileStream fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Append))
                {
                  byte[] buffer = new byte[4096];
                  try
                  {
                    int bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                    while (bytesRead > 0)
                    {
                      fileStream.Write(buffer, 0, bytesRead);
                      bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                    }
                    return true;
                  }
                  catch (System.Net.WebException)
                  {
                    // Do nothing - consume this exception to force a new read of the rest of the file
                  }
                }
                if (System.IO.File.Exists(filePath))
                {
                  offset = new System.IO.FileInfo(filePath).Length;
                }
                else
                {
                  offset = 0;
                }
                
                retryCount--;
                if (offset == length)
                {
                  return true;
                }
              }
            }
