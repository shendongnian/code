    static private void CompressDirRecursive(string path, ref Ionic.Zip.ZipFile dzip)
    {
    	dzip.AddFiles((System.IO.Directory.GetFiles(path)), false, path); // ROOT
    	
    	foreach (string dir in System.IO.Directory.GetDirectories(path))
    	{
    		CompressDirRecursive(dir, ref dzip);// NEXT DIRECTORY
    	}
    }
    
    static private void MyTestFunction()
    {
    	Ionic.Zip.ZipFile dzip = new Ionic.Zip.ZipFile();
    	System.IO.MemoryStream msOut = new System.IO.MemoryStream();
    	CompressDirRecursive("ruta que quieras", ref dzip);
    	try
    	{
    		dzip.Save(outputStream: msOut);
    	}
    	catch (Exception ex)
    	{
    		throw ex;
    	}
    	
    	dzip.Dispose();
    	// etc
    }
