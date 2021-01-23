    bool success = false;
    while (!success)
    {
        try
        {
            using(Stream file = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                // Read current content from file.
                // Make changes
                // Save new content to file.
            }
            success = true;
        }
        catch(IOException e)
        {
            // Someone else was modifying the file.
        }
    }
