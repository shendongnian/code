    BitmapImage image1 = LoadImageToMemory("C:\\image.png");
    BitmapImage image2 = LoadImageToMemory(webRequest.GetResponse().GetResponseStream());
    public BitmapImage LoadImageToMemory(string path)
    {
            BitmapImage image = new BitmapImage();
            try
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                System.IO.Stream stream = System.IO.File.Open(path, System.IO.FileMode.Open);
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
