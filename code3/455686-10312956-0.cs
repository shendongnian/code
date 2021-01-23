    QRCodeWriter writer = new QRCodeWriter();
    var bMatrix = writer.encode("Hey dude! QR FTW!", BarcodeFormat.QR_CODE, width, height);
    
    WriteableBitmap wbmi = new System.Windows.Media.Imaging.WriteableBitmap(width, height);
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            int grayValue = bMatrix.Array[y][x] & 0xff;
            if (grayValue == 0)                        
                wbmi.SetPixel(x, y, Color.FromArgb(255, 0, 0,0));                                                    
             else
                 wbmi.SetPixel(x, y, Color.FromArgb(255, 255, 255, 255));
         }
     }
     image1.Source = wbmi;
