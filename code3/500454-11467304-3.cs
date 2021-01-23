    StreamWriter sr;
    try
    {
    	sr = new StreamWriter(streamFolder);
    	sr.Write(details);
    	File.SetAttributes(streamFolder, FileAttributes.Hidden);
    }
    catch(IOException ex)
    {
    	//handling IO
    }
    finally
    {
        if (sr != null)
    	    sr.Dispose();
    }
