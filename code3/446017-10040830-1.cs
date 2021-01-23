    public Window2()
    {
        InitializeComponent();
        var open = new OpenFileDialog();
        open.ShowDialog();
        var localImage = new Bitmap(open.FileName);
        var stream = new MemoryStream();
        localImage.Save(stream, ImageFormat.Png);
        var byteArray = ImageToByteArray(localImage);
        var imageAgain = ByteArrayToImage(byteArray);
        var imageSource = new BitmapImage();
        imageSource.BeginInit();
        var ms = new MemoryStream();
        imageAgain.Save(ms, ImageFormat.Bmp);
        ms.Seek(0, SeekOrigin.Begin);
        imageSource.StreamSource = ms;
        imageSource.EndInit();
        image.Source = imageSource;
    }
    public byte[] ImageToByteArray(System.Drawing.Image imageIn)
    {
        var memoryStream = new MemoryStream();
        imageIn.Save(memoryStream, ImageFormat.Gif);
        return memoryStream.ToArray();
    }
    public System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
    {
        return System.Drawing.Image.FromStream(new MemoryStream(byteArrayIn));
    }
