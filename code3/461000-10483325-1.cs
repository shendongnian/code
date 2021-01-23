    public static void SetPicture(string filename, PictureBox pb)
    {
        try
        {
            Image currentImage;
            byte[] imageBytes = File.ReadAllBytes(filename);
            using(MemoryStream msImage = new MemoryStream(imageBytes))
            {
                currentImage = ScaleImage(Image.FromStream(msImage), new Size(pb.Width, pb.Height));
            ....
    }
