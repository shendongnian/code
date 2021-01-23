    private static int FirstExisting()
    {
        foreach (int i in UniqueRandom(0, 4))
        {
            var wbImage = GetCharBitmap(c, rndFolder, i);
            if (wbImage != null)
            {
                return i;
            }
        }
        throw new Exception("No existing found"); // or return say -1
    }
