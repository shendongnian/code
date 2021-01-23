    try
    {
    	 using (StreamWriter sw = File.AppendText(dir))
    	 {
    		  sw.WriteLine("test");
    	 }
    }
    catch (Exception ex)
    {
    	 Debug.Print(ex.Message);
    }
