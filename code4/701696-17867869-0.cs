    try
    {
        directory.GetFiles();
    }
    catch (UnauthorizedAccessException)
    {
        string logMsg = string.Format("Unable to access directory {0}", directory.FullName);
        //Handle any desired logging here
    }
