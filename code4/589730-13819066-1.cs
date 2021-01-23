    public BitmapImage LoadImageToMemory(System.IO.Stream stream)
        {
            if (stream.CanRead)
            {
                BitmapImage image = new BitmapImage();
                try
                {
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = new System.IO.MemoryStream();
                    stream.CopyTo(image.StreamSource);
                    image.EndInit();
                    stream.Close();
                    stream.Dispose();
                    image.StreamSource.Close();
                    image.StreamSource.Dispose();
                }
                catch { throw; }
                return image;
            }
            throw new Exception("Cannot read from stream");
    }
