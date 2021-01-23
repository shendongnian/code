    public void ResizeImage(string fileName, int width, int height)
    {
        using (Image image = Image.FromFile(fileName))
        {
            using (Image newImage = new Bitmap(image, width, height))
            {
                //must dispose the original image to free up the file ready
                //for re-write, otherwise saving will throw an error
                image.Dispose();
                newImage.Save(fileName);
            }
        }
    }
