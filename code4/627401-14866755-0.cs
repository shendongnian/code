    try
    {
        Bitmap tempImage = new Bitmap(item.Image);
        tempImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
    }
    catch (Exception e)
    {
        Debug.WriteLine("DEBUG::LoadImages()::Error attempting to create image::" + e.Message);
    }
