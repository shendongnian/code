    public Image SaveImage(string image)
    {
        //get a temp image from bytes, instead of loading from disk
        //data:image/gif;base64,
        //this image is a single pixel (black)
        byte[] bytes = Convert.FromBase64String(image);
        Image image;
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            image = Image.FromStream(ms);
        }
        image.Save("fullOutputPath", System.Drawing.Imaging.ImageFormat.Png);
        
         return image;
    }
