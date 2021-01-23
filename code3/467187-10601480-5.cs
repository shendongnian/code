    int[] GetIntArray(int num)
    {
        List<int> listOfInts = new List<int>();
        while(num > 0)
        {
            listOfInts.Add(num % 10);
            num /= 10;
        }
        listOfInts.Reverse();
        return listOfInts.ToArray();
    }
    int GetSimilarity(int firstNo, int secondNo)
    {
        int[] firstintarray = GetIntArray(firstNo)
        int[] secondintarray = GetIntArray(secondNo)
        if (firstintarray.Count != secondintarray.Count)
        {
            throw new ArgumentException("Numbers Unequal in Length!");
        }
        int similarity = 0;
        for(i = 0; i < firstintarray.Count; i++)
        {
            if (secondintarray[i] = firstintarray[i])
            {
                similarity++;
                continue;
            }
            break;
        }
    }
