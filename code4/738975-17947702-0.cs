    private List<BitmapImage> Images = .....;
    private List<BitmapImage>.Enumerator iterator;
    private List<byte[]> bytesData = new List<byte[]>();
    
    public void ProcessImages()
    {
        if(iterator == null)
            iterator = Images.GetEnumerator();
        if(iterator.MoveNext())
        {
            bytesData.Add(ConvertToBytes(iterator.Current));
            //load next images
            Dispatcher.BeginInvoke(() => ProcessImages());
        }else{
            //all images done
        }
    }
    public static byte[] ConvertToBytes(BitmapImage bitmapImage)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            var wBitmap = new WriteableBitmap(bitmapImage);
            wBitmap.SaveJpeg(stream, wBitmap.PixelWidth, wBitmap.PixelHeight, 0, 100);
            stream.Seek(0, SeekOrigin.Begin);
            return stream.ToArray();
        }
    }
