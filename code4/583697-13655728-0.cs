    protected override void OnRender(System.Windows.Media.DrawingContext dc)
    {
        int halfWidth = (int)this.Width / 2;
        int height = (int)this.Height;
        BitmapImage leftImage = new BitmapImage(new Uri(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg"));
        BitmapImage rightImage = new BitmapImage(new Uri(@"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg"));
        CroppedBitmap leftImageCropped = new CroppedBitmap(leftImage, new Int32Rect(0, 0, halfWidth, height));
        CroppedBitmap rightImageCropped = new CroppedBitmap(rightImage, new Int32Rect(0, 0, halfWidth, height));
        dc.DrawImage(leftImageCropped, new System.Windows.Rect(0, 0, leftImageCropped.Width, height));
        dc.DrawImage(rightImageCropped, new System.Windows.Rect(halfWidth, 0, halfWidth, height));
    }
