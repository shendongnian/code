    private Bitmap GetBitmapFromStream(String bitmapKeyName)
    {
        MemoryStream ms = dict[bitmapKeyName];
        ms.Seek(0, SeekOrigin.Begin);
        return new Bitmap(ms);
    }
    public Image<Bgr, Byte> Draw(String modelImageFileName, String observedImageFileName, out long matchTime,int i)
    {
       Image<Gray, Byte> modelImage = new Image<Gray, byte>(GetBitmapFromStream(modelImageFileName));
       Image<Gray, Byte> observedImage = new Image<Gray, byte>(GetBitmapFromStream(observedImageFileName));
    }
