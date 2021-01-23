    try 
    {
        subSubDirs = subDir.GetDirectories();
    }
    catch(UnauthorizedAccessException uae)
    {
      //log that subDir.GetDirectories was not possible
    }
