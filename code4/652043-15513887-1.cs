    public void Do(string workGif)
    {
        // ...
        string qrInfo;
        using (var fullImg = new Bitmap(workGif))
        {
            for (int i = 0; i < 4; i++)
            {
                // Does the image contain a QR code?
                qrInfo = Process(fullImg);
                if (qrInfo = null)
                    // No QR code found. Rotate the image.
                    fullImg.RotateFlip(RotateFlipType.Rotate90FlipNone);
                else
                    // QR code found. Break out of the loop.
                    break;
            }
            if (qrInfo == null)
            {
                throw new InvalidOperationException(
                    "The document contains no QR code.");
            }
        }
        MessageBox.Show(qrInfo);
        // ...
    }
    
