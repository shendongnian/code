    public IEnumerable<List<int>> YieldCombinationsOfN(int places, int digitMin, int digitMax)
    {            
        int n = digitMax - digitMin + 1;
        int numericMax = (int)Math.Pow(n, places);
        for (int i = 0; i < numericMax; i++)
        {
            List<int> li = new List<int>(places);
            for(int digit = 0; digit < places; digit++)
            {
                li.Add(((int)(i / Math.Pow(n, digit)) % n) + digitMin);
            }
            yield return li;
        }
    }
