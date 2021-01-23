    public bool IsImageValid(string filename)
    {
        try
        {
            System.Drawing.Image newImage = System.Drawing.Image.FromFile(filename);
        }
        catch (OutOfMemoryException ex)
        {
            // Image.FromFile will throw this if file is invalid.
            // Don't ask me why.
            return false;
        }
        return true;
    }
