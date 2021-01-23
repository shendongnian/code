    public static int CountSetBits(this BitArray theBitArray)
    {
       int count = 0;
       for (int i = 0; i < theBitArray.Count; i++)
       {
          count += (theBitArray.Get(i)) ? 1 : 0;
       }
       return count; 
    }
