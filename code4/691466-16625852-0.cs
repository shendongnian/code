    using (sc = new ServiceClient())
    {
        using (Byte[] array = sc.GetImage())
        {
            Display = new BitmapImage();
            Display.BeginInit();
            Display.StreamSource = new MemoryStream(array );
            Display.EndInit();
        }
    }
