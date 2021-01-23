    public static Image ScaleImage(Image image, int maxWidth)
    {    
        var newImage = new Bitmap(newWidth, image.Height);
        Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, image.Height);
        return newImage;
    }
