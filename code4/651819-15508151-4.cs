    string text = null;
    for(int i = 0; i < 4; i++) {
        var bandImg = img.Clone(new System.Drawing.Rectangle(0, 0, 375, 375), 
                fullImg.PixelFormat);
        text = Process(bandImg)
    
        if(text != null) break;
        else img.RotateFlip(RotateFlipType.Rotate90FlipNone);
    }
