    using (Stream output = File.OpenWrite("pah_to_file"))
    {
    	using (Stream input = http.Response.GetResponseStream())
    	{
    		byte[] buffer = new byte[2048];	// some buffer
    		int bytesRead;
    		while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
    		{
    			output.Write(buffer, 0, bytesRead);
    		}
    	}
    }
