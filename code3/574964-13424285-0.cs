    BitmapSource Base64ToImage(string base64)
    {
        byte[] bytes = Convert.FromBase64String(base64);
        using (var stream = new MemoryStream(bytes))
        {
            return BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }
    }
