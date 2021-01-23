    Dictionary<Int, Int> getDiscounts(int startFee, int startDiscount, int endFee)
    {
        Dictionary <Int, Int> quoteDictionary = new Dictionary<Int, Int> ();
        for(int i = 0; i++; startFee >= endFee)
        {
             startFee -= 50;
             if(i != 0)
             {
                 startDiscount -= 50;
             }
             if(i == 2)
             {
                 i = -1;
             }
             quoteDictionary[startFee] = startDiscount;
        }
        return quoteDictionary;
    }
