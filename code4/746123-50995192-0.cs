    BitmapImage bi = new BitmapImage(
        new Uri("pack://application:,,,/AppName.Modules.App.Shared;component/Images/AppName_logo.png"));
    Bitmap b = BitmapImage2Bitmap(bi);
    private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
    {
        using (MemoryStream outStream = new MemoryStream())
        {
            BitmapEncoder enc = new BmpBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(bitmapImage));
            enc.Save(outStream);
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);
            return new Bitmap(bitmap);
        }
    }
