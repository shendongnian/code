    double x = 0;
    double y = 0;
    double w = 0;
    double h = 0;
    
    double inputX = 10;
    double inputY = 10;
    double inputW = 20;
    double inputH = 30;
    
    // integer division " 10 / 100 " will return 0, use doubles or floats.
    // furthermore you don't have to convert anything to a string or back here.
    x = __Bitmap.Width * inputX / 100.0;
    y = __Bitmap.Height * inputY / 100.0;
    
    w = __Bitmap.Width * inputW / 100.0;
    h = __Bitmap.Height * inputH / 100.0;
    
    // casting to int will just cut off all decimal places. you could also round.
    Rectangle cropArea = new Rectangle((int)x, (int)y, (int)w, (int)h);
    Bitmap bmpCrop = __Bitmap.Clone(cropArea, __Bitmap.PixelFormat);
