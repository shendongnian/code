    byte[] buffer = new byte[512];
    try
    {
    	 using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
    	 {
    		  fs.Read(buffer, 0, buffer.Length);
    		  fs.Close();
    	 }
    }
    catch (System.UnauthorizedAccessException ex)
    {
    	 Debug.Print(ex.Message);
    }
