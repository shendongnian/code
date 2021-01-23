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
            //maybe print the error if you want
            Debug.WriteLine("An error occurred while searching for the QR code: " + e.Message);
            
            //returning null here means you know the QR was not found
            return null;
        }
    }
