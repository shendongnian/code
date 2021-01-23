    try
    {
        using (Stream ftpStream = FTPRequest.GetRequestStream())
        {
            using (FileStream file = File.OpenRead(ImagesZipFile))
            {
                // set up variables we'll use to read the file
                int length = 1024;
                byte[] buffer = new byte[length];
                int bytesRead = 0;
                // write the file to the request stream
                do
                {
                    bytesRead = file.Read(buffer, 0, length);
                    ftpStream.Write(buffer, 0, bytesRead);
                }
                while (bytesRead != 0);
            }
        }
    }
    catch (Exception e)
    {
        // throw the exception
        throw e;
    }
