    try
    {
        ...
    }
    catch(UnauthorizedAccessException)
    {
        throw;
    }
    catch(DirectoryNotFoundException)
    {
        throw;
    }
    catch(PathTooLongException)
    {
        throw;
    }
    catch(IOException e)
    {
        ... assume file exists
    }
