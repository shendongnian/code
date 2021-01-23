    Bitmap bitmap = new Bitmap(@"C:\MyImagePath.jpg");
    int[,] imgArray = new int[bitmap.Width, bitmap.Height];
    for(int i = 0; i < bitmap.Width; ++i)
    {
        for(int j = 0; j < bitmap.Height, ++i)
        {
            Color pixelCol = bitmap.GetPixel(i, j);
            if(pixelCol == Color.Black)
            {
               imgArray[i,j] = 1;
            }
            else if(pixelColor == Color.White)
            {
               imgArray[i,j] = 0;
            }
            else
                throw new InvalidOperationException("Pixel color must be black or white");
        }
    }
