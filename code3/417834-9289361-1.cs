    try
    {
       if ( File.Exists (path) )
       {
          File.Delete(pathToStore);
          File.Copy(path, pathToStore);
       }
    }
    catch(Exception Ex)
    { 
    // do something with the Exception! 
    }
