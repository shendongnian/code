    using (sc = new ServiceClient())
        {
                Byte[] array = sc.GetImage();
                Display = new BitmapImage();
                Display.BeginInit();
                Display.StreamSource = new MemoryStream(array);
                Display.EndInit();
         }
