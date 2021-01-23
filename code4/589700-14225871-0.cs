    public static void DisposeImage(BitmapImage img)
        {
            Uri uri= new Uri("oneXone.png", UriKind.Relative);
            StreamResourceInfo sr=Application.GetResourceStream(uri);
            try
            {
             using (Stream stream=sr.Stream)
             {
              image.DecodePixelWidth=1; //This is essential!
              image.SetSource(stream);
             }
            }
            catch
            {}
    }
