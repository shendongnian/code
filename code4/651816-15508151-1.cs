    string qrCode;
    using (var fullImg = new Bitmap(workGif)) {
        var bandImg = fullImg.Clone(new System.Drawing.Rectangle(0, 0, 375, 375), fullImg.PixelFormat);
        qrCode = ReadQrCode(bandImg);
    }
