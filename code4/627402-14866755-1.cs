    try
    {
       using (Bitmap tempImage = new Bitmap(item.Image)) 
       {
          tempImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
       }    
    }
    catch (Exception e)
    {
        Debug.WriteLine("DEBUG::LoadImages()::Error attempting to create image::" + e.Message);
    }
