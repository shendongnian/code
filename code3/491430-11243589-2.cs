    public static unsafe byte[,] GetWeight(Bitmap a)
    {
        BitmapData aData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadOnly, a.PixelFormat);
        const int pixelSize = 4;
    
        byte[,] weight = new byte[aData.Width, aData.Height];
        for (int y = 0; y < aData.Height; y++)
        {
            byte* aRow = (byte*)aData.Scan0 + (y * aData.Stride);
            for (int x = 0; x < aData.Width; x++)
            {
                byte aWeight = aRow[x * pixelSize + 3];
                weight[x, y] = aWeight;
            }
        }
        a.UnlockBits(aData);
        return weight;
    }
    
    public static double GetSimilarity(byte[,] weightsA, byte[,] weightsB)
    {
        double sum = 0;
        int height = weightsA.GetLength(1);
        int width = weightsA.GetLength(0);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                byte aWeight = weightsA[x,y];
                byte bWeight = weightsB[x, y];
                sum += Math.Abs(aWeight - bWeight);
            }
        }
    
        return 1 - ((sum / 255) / (width * height));
    }
