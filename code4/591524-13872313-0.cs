        if (value == null)
            return null;
        string imageBase64String = (string)value;
        byte[] imageAsBytes = Convert.FromBase64String(imageBase64String);
        System.Windows.Media.Imaging.BitmapDecoder.Create(
        var decoder = new 
        var bitmap = new System.Windows.Media.Imaging.BitmapImage();
        bitmap.BeginInit();
        MemoryStream memoryStream = new MemoryStream();
        image.Save(memoryStream, image.RawFormat);
        memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
        bitmap.StreamSource = memoryStream;
        bitmap.EndInit();
        return bitmap;
    } 
