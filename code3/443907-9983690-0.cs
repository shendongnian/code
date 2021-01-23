    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.IO;
    ...
            Stream stream = new MemoryStream(Properties.Resources.marble8);
            PngBitmapDecoder decoder = new PngBitmapDecoder(stream, 
                BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];
