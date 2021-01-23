    public static class Categories
    {
       public const int Category1 = 1;
       public const int Category2 = 2;
        //...
       public const int Category3123 = 3123;
       public const int Max = 5000;
    }
    
    BitArray myBitset = new BitArray((int)Categories.Max);
    myBitSet.Set(Categories.Category1);
    myBitSet.Set(Categories.Category4);
