    public Image GetPicture()
    {
        try
        {
           Image image = GetImageFromDb();
           return image;
        }
        catch(Exception ex)
        {
        
        }
    }
