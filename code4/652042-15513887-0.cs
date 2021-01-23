    public void Do(string workGif)
    {
        // ...
        using (var fullImg = new Bitmap(workGif))
        {
            var bandImg = fullImg.Clone(new System.Drawing.Rectangle(0, 0, 375, 375), fullImg.PixelFormat);
            
            RotateImageProperly(bandImg);
            ProcessQRCode(bandImg);
        }
        // ...
    }
    
    private void RotateImageProperly(Image bandImg)
    {
        for (int i = 0; i < 4; i++)
        {
            bandImg.RotateFlip(RotateFlipType.Rotate90FlipNone
            if (HasProperQRCode(bandImg))
                break;
        }
        if (!HasProperQRCode(bandImg))
            throw new InvalidOperationException("The document contains no QR code.");
    }
