    public static void SetPicture(string filename, PictureBox pb)
    {
        try
        {
            Image currentImage;
            string tempFile = Path.Combine(Path.GetTempDirectory(), Guid.NewGuid().ToString() + Path.GetExtension(filename));
            File.Copy(filename, tempFile);
            //currentImage = ImageFast.FromFile(filename);
            using (FileStream fsImage = new FileStream(tempFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                ...
