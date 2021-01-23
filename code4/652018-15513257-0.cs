    void Method2(string file_name, byte[] file)
    {
    	var path = file_name;
        int file_size_int = file.Length;
    	if (File.Exists(path))
    	{
    		File.Delete(path);
    	}
        FileStream create = File.OpenWrite(path);
        var attributes = File.GetAttributes(path);
        File.SetAttributes(path, attributes | FileAttributes.Temporary);
        create.Close();
        Process p = Process.Start(path);
    	
    	while (!p.HasExited)  
    	{
    		Thread.Sleep(100);  
    	}
    	
        File.Delete(path);
    }
