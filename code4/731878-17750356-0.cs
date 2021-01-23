    public void ResizeImage(string fileName, int width, int height)
    {
        using (Image image = Image.FromFile(fileName))
        {
            using (Image newImage = new Bitmap(image, width, height))
            {
                image.Dispose();//must dispose the original image to free up the file ready for re-write
                newImage.Save(fileName);
            }
        }
    }
