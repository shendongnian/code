    private byte[] DisplayPhoto(byte[] photo)
    {
        if (!(photo == null))
        {
            MemoryStream stream = new MemoryStream();
            stream.Write(photo, 0, photo.Length);
            stream.Position = 0;
            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            memoryStream.Seek(0, SeekOrigin.Begin);
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();
            ResidentImage.Source = bitmapImage;
    
            ResidentProfileImage.Source = bitmapImage;
            return stream.ToArray();
        }
        else
        {
            ResidentImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/ResidentImage.jpg"));
        }
        return new byte[0];
    }
