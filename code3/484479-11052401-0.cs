    public bool IsPresentInArray(int[] firstArray, int[] secondArray)
    {
        foreach (var itemA in firstArray)
        {
            foreach (var itemB in secondArray)
            {
                if (itemB == itemA)
                {                       
                    return true;
                }
            }
        }
        return false;
    }
