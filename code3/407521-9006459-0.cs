    try
    {
    	pProcess.StandardInput.Write(File.ReadAllText("file.txt"));
    }
    finally
    {
    	pProcess.StandardInput.Close();
    }
