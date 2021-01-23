    private void ScanQRPdf(string imagePath)
    {
        foreach (var decodedString in DecodeAllImagesInFolder(imagePath))
        {
            rtbpdfData.Text += decodedString + "\n";
        }
    }
    private static IEnumerable<string> DecodeAllImagesInFolder(string imagePath)
    {
        foreach (var item in Directory.GetFiles(imagePath, "*.png"))
        {
            using (Bitmap b = new Bitmap(imagePath))
            {
                yield return DecodeTopLeftCorner(b);
            }
        }
    }
    private static string DecodeTopLeftCorner(Bitmap bitmap)
    {
        var rect = new Rectangle(0, 0, 100, 100);
        using (var topLeft = bitmap.Clone(rect, bitmap.PixelFormat))
        {
            return new QRCodeDecoder().decode(new QRCodeBitmapImage(topLeft));
        }
    }
