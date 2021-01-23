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
            // Apart from the message (in different languages) there is no way to tell
            // if it was a sharing violation or another IO exception.
        }
    }
