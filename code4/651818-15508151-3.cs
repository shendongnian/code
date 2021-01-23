    string ReadQrCode(Bitmap img, int n = 0) {
        if(n == 4) return null;
        
        var bandImg = img.Clone(new System.Drawing.Rectangle(0, 0, 375, 375), 
            fullImg.PixelFormat);
        string text = Process(bandImg);
        if(text == null) {
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            text = ReadQrCode(img, n + 1);
        }
        return Text;
    }
    
