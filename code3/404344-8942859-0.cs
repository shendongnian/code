    using System.Windows.Media.Imaging;
    public static byte[] ConvertBitmapSourceToByteArray(BitmapSource imageToConvert, ImageFormat formatOfImage)
    {
        byte[] buffer;
        try
        {
            using (var ms = new MemoryStream())
            {
                switch (formatOfImage)
                {
                    case ImageFormat.Png:
                        var bencoder = new PngBitmapEncoder();
                        bencoder.Frames.Add(BitmapFrame.Create(imageToConvert));
                        bencoder.Save(ms);
                        break;
                    case ImageFormat.Tiff:
                        var tencoder = new TiffBitmapEncoder();
                        tencoder.Compression = TiffCompressOption.Ccitt4;
                        tencoder.Frames.Add(BitmapFrame.Create(imageToConvert));
                        tencoder.Save(ms);
                        break;
                }
                ms.Flush();
                buffer = ms.GetBuffer();
            }
        }
        catch (Exception) { throw; }
        return buffer;
    }
