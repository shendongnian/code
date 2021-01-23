    unsafe System.Array ToIntPtrArray(System.Array a)
    {
        int[] lengths = new int[a.Rank];
        int[] lowerBounds = new int[a.Rank];
        for (int i = 0; i < a.Rank; ++i)
        {
            lengths[i] = a.GetLength(i);
            lowerBounds[i] = a.GetLowerBound(i);
        }
        Array newArray = Array.CreateInstance(typeof (IntPtr), lengths, lowerBounds);
            
        // The hard part is iterating over the array.
        // Multiplying the lengths will give you the total number of items.
        // Then we go from 0 to n-1, and create the indexes
        // This loop could be combined with the loop above.
        int numItems = 1;
        for (int i = 0; i < a.Rank; ++i)
        {
            numItems *= lengths[i];
        }
        int[] indexes = new int[a.Rank];
        for (int i = 0; i < numItems; ++i)
        {
            int work = i;
            int inc = 1;
            for (int r = a.Rank-1; r >= 0; --r)
            {
                int ix = work%lengths[r];
                indexes[r] = lowerBounds[r] + ix;
                work -= (ix*inc);
                inc *= lengths[r];
            }
            object obj = a.GetValue(indexes);
            // somehow create an IntPtr from a boxed pointer
            var myPtr = new IntPtr((long) obj);
            newArray.SetValue(myPtr, indexes);
        }
        return newArray;
    }
