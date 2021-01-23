    // pass parameters according to your need, 
    // the below code is done in a hard coded manner for clarity
    public void Copy()	
    {
        // from where you want to copy
    	var downloadRequest = (FtpWebRequest)WebRequest.Create("ftp://www.mysite.com/test.jpg");
    	downloadRequest.Credentials = new NetworkCredential("userName", "passWord");
    	downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
    
    	var ftpWebResponse = (FtpWebResponse)downloadRequest.GetResponse();
    	var downloadResponse = ftpWebResponse.GetResponseStream();
    
    	int buffLength = 2048;
    	byte[] byteBuffer = new byte[buffLength];
    
    	// bytes read from download stream. 
    	// from documentation: When overridden in a derived class, reads a sequence of bytes from the  
    	// current stream and advances the position within the stream by the number of bytes read.
    	int bytesRead = downloadResponse.Read(byteBuffer, 0, buffLength);
    
        // the place where you want the file to go
    	var uploadRequest = (FtpWebRequest)WebRequest.Create("ftp://www.mysite.com/testCopy.jpg");
    	uploadRequest.Credentials = new NetworkCredential("userName", "passWord");
    	uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;
    
    	var uploadStream = uploadRequest.GetRequestStream();
    
    	if (bytesRead > 0)
    	{
    		while (bytesRead > 0)
    		{
    			uploadStream.Write(byteBuffer, 0, bytesRead);
    			bytesRead = downloadResponse.Read(byteBuffer, 0, buffLength);
    		}
    	}
    
    	uploadStream.Close();
    	uploadStream.Dispose();
    
    	downloadResponse.Close();
    	ftpWebResponse.Close();
    	((IDisposable)ftpWebResponse).Dispose();
    }
