    public bool UploadFtpFile(string folderName, string fileName)
    {
    
    FtpWebRequest request;
    try
    {
    	string folderName; 
    	string fileName;
    	string absoluteFileName = Path.GetFileName(fileName);
    	
    	request = WebRequest.Create(new Uri(string.Format(@"ftp://{0}/{1}/{2}", "127.0.0.1", folderName, absoluteFileName))) as FtpWebRequest;
    	request.Method = WebRequestMethods.Ftp.UploadFile;
    	request.UseBinary = 1;
    	request.UsePassive = 1;
    	request.KeepAlive = 1;
    	request.Credentials =  new NetworkCredential(user, pass);
    	request.ConnectionGroupName = "group"; 
    
    	using (FileStream fs = File.OpenRead(fileName))
    	{
    		byte[] buffer = new byte[fs.Length];
    		fs.Read(buffer, 0, buffer.Length);
    		fs.Close();
    		Stream requestStream = request.GetRequestStream();
    		requestStream.Write(buffer, 0, buffer.Length);
    		requestStream.Close();
    		requestStream.Flush();
    	}
    }
    catch (Exception ex)
    {
       
    }
    }
