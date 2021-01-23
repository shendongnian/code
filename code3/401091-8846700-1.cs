    public bool IsValidGDIPlusImage(byte[] imageData)
    {
        try
        {
            using (var ms = new MemoryStream(imageData))
            {
                using (var bmp = new Bitmap(ms))
                {
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
