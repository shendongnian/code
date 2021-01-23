    private Image GetCornerImage(Image sourceImage)
    {
        return sourceImage.Clone(new Rectangle(0, 0, 375, 375), sourceImage.PixelFormat);
    }
    
    public string Process(Bitmap bitmap)
    {
        var cornerImg = GetCornerImage(bitmap);
        
        var reader = new com.google.zxing.qrcode.QRCodeReader();
        LuminanceSource source = new RGBLuminanceSource(
            cornerImg, cornerImg.Width, cornerImg.Height);
        var binarizer = new HybridBinarizer(source);
        var binBitmap = new BinaryBitmap(binarizer);
        return reader.decode(binBitmap).Text;
    }
