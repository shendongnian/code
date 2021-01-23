    private void SaveImage(Image image, string path)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
            var jpegEncoder = new JpegBitmapEncoder();
            jpegEncoder.Frames.Add(BitmapFrame.Create(ms));
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                jpegEncoder.Save(fs);
            }
        }
