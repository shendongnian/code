    class FTPHelper
    {
    	public FTPHelper(string address, string login, string password)
    	{
    		Address = address;
    		Login = login;
    		Password = password;
    	}
    
    	public void Upload(MemoryStream stream, string fileName)
    	{
    		try
    		{
    			FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Address + @"/" + fileName);
    			request.Method = WebRequestMethods.Ftp.UploadFile;
    			request.Credentials = new NetworkCredential(Login,Password);
    
    			request.UseBinary = true;
    
    			byte[] buffer = new byte[stream.Length];
    			stream.Read(buffer, 0, buffer.Length);
    			stream.Close();
    	
    			Stream requestStream = request.GetRequestStream();
    			requestStream.Write(buffer, 0, buffer.Length);
    			requestStream.Close();
    
    			FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    			Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
    			response.Close();
    		}
    		catch (Exception)
    		{
    			throw;
    		}
    	}
    
    	public string Address { get; set; }
    	public string Login { get; set; }
    	public string Password { get; set; }
    }
