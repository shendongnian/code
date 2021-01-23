    public const double PERCENT_MATCH = 0.9;
    int noMatchCount = 0;
    for (int x = 0; x < irMainX; x++)
    {
        for (int y = 0; y < irMainY; y++)
        {
           if ( !pixelsMatch( image.GetPixel(x,y), srClickedArray[x%16, y%16] )
           {
               noMatchCount++;
               if ( noMatchCount > ( 16 * 16 * ( 1.0 - PERCENT_MATCH ))
                  goto matchFailed;
           }
        }
    }
    Console.WriteLine("images are >=90% identical");
    return;
    matchFailed:
    Console.WriteLine("image are <90% identical");
