    var myPalette = new BitmapPalette(new List<Color> 
    { 
        Colors.Red,
        Colors.Blue,
        Colors.Green,
        // ...
    });
    
    var writeableBitmap = new WriteableBitmap(
        width, 
        height, 
        96, 
        96, 
        PixelFormats.Indexed8, // Paletted bitmap with 256 colours
        myPalette);
    
    writeableBitmap.WritePixels(...);
