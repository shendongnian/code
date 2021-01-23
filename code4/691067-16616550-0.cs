    try
    {
        using (var fs = new FileStream("foo", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
        {
            try
            {
                // do stuff with file.
            }
            catch (IOException ex)
            {
                // handle exceptions that occurred while working with file
            }
        }
    }
    catch (IOException openEx)
    {
        // unable to open file
    }
