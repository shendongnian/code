    public bool SaveImage(IList<AppConfig> AppConfigs, string ImageNameFilter)
    {
        string imgPath = AppConfigs[0].ConfigValue.ToString();
    	File.Copy(selectedFile, imgPath + "\\" + ImageNameFilter + slectedFileName + ".jpeg");
    }
    
    ...
    
    try
    {
    	xxx.SaveImage(....);
    }
    catch (UnauthorizedAccessException)
    {
    	// Message to user that the access is denied?
    	...
    }
    catch (any exception you can handle properly)
    {
    	
    }
    catch
    {
    	// Couln't be handled properly, so displays generic error message
    	...
    }
