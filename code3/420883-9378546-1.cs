    try
    {
    	string file = "...";
    	bool hasWritePermission = HasWritePermissionOnFile(file);
    	using (FileStream fs = new FileStream(file, FileMode.Open))
    	{
    	}
    }
    catch (UnauthorizedAccessException ex)
    {
    	// Insert some logic here
    }
    catch (FileNotFoundException ex)
    {
    	// Insert some logic here
    }
    catch (IOException ex)
    {
    	// Insert some logic here
    }
