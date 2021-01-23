    private byte[] GenerateBarCodeZXing(string data)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.PDF_417,
            Options = new EncodingOptions { Width = 200, Height = 50 } //optional
        };
        var imgBitmap = writer.Write(data);
        using (var stream = new MemoryStream())
        {
            imgBitmap.Save(stream, ImageFormat.Png);
            return stream.ToArray();
        }
    }
