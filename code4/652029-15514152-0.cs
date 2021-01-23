    //Initialize image and stuff
    int Width = 100;
    int Height = 100;
    int nStride = (Width * PixelFormats.Bgra32.BitsPerPixel + 7) / 8;
    Int32Rect ImageDimentions = new Int32Rect(0, 0, Width, Height);
    int[] ImageArr = new ImageArr[Height * nStride];
    //Manually paint your image
    for (int Y = 0; Y < Height; Y++)
    {
        for (int X = 0; X < Width; X++)
        {
           //X and Y means pixel(X,Y) in cartesian plane 1 quadrant mirrored around X axis
           //Down is the Y from 0 to height, and right to left is X from 0 to width
           int index = (Y * Width + X) * 4;
           ImageArr[index + 0] = (byte)0;   //Blue
           ImageArr[index + 1] = (byte)0;   //Green
           ImageArr[index + 2] = (byte)0;   //Red
           ImageArr[index + 3] = (byte)255; //Alpha
        }
    }
    //Push your data to a Bitmap
    WriteableBitmap BmpToWriteOn = new WriteableBitmap(Width, Height, 96, 96, PixelFormats.Bgra32, null);
    BmpToWriteOn.WritePixels(ImageDimentions, ImageArr, nStride, 0, 0);     
    //Push your bitmap to Xaml Image
    YourXamlImage.Source = BmpToWriteOn;
