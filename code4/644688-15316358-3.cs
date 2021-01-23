    var bitmap = new Bitmap(@"C:\MyImage.png");
    var imgArray = new int[bitmap.Width,bitmap.Height];
    var blackArgb = Color.Black.ToArgb();
    var whiteArgb = Color.White.ToArgb();
    for (var i = 0; i < bitmap.Width; ++i)
    {
        for (var j = 0; j < bitmap.Height; ++j)
        {
            var pixelCol = bitmap.GetPixel(i, j);
            if (pixelCol.ToArgb() == blackArgb)
            {
                imgArray[i, j] = 1;
            }
            else if (pixelCol.ToArgb() == whiteArgb)
            {
                imgArray[i, j] = 0;
            }
            else
                throw new InvalidOperationException("Pixel color must be black or white");
        }
    }
