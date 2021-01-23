    public bool CheckColIfWhite(Bitmap image,int colx)
    {
        for (int y = 0; y < image.Height; y++)
        {
            if (image.GetPixel(colx,y).R < 200)
                return false;
        }
        return true;
    }
