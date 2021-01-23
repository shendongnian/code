    public string Process(Bitmap bitmap)
    {
        var reader = new com.google.zxing.qrcode.QRCodeReader();
        try
        {
            LuminanceSource source = new RGBLuminanceSource(bitmap, bitmap.Width, bitmap.Height);
            var binarizer = new HybridBinarizer(source);
            var binBitmap = new BinaryBitmap(binarizer);
            return reader.decode(binBitmap).Text;
        }
        catch (Exception e)
        {
            //catch the exception and return null instead
            return null;
        }
    }
