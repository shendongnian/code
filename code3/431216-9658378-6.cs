    public static List<List<T>> PowerSet<T>(List<T> startingSet, int minSubsetSize)
    {
        List<List<T>> subsetList = new List<List<T>>();
        //The set bits of each intermediate value represent unique 
        //combinations from the startingSet.
        //We can start checking for combinations at (1<<minSubsetSize)-1 since
        //values less than that will not yield large enough subsets.
        int iLimit = 1 << startingSet.Count;
        for (int i = (1 << minSubsetSize)-1; i < iLimit; i++)
        {
            //Get the number of 1's in this 'i'
            int setBitCount = NumberOfSetBits(i);
            //Only include this subset if it will have at least minSubsetSize members.
            if (setBitCount >= minSubsetSize)
            {
                List<T> subset = new List<T>(setBitCount);
                for (int j = 0; j < startingSet.Count; j++)
                {
                    //If the j'th bit in i is set, 
                    //then add the j'th element of the startingSet to this subset.
                    if ((i & (1 << j)) != 0)
                    {
                        subset.Add(startingSet[j]);
                    }
                }
                subsetList.Add(subset);
            }
        }
        return subsetList;
    }
