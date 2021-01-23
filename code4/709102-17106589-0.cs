    void sample()
    {
        SortedDictionary<String, String>.KeyCollection keyColl = clrDatesSelectedSortedDict.Keys;
        for (Int32 i = 0; i < keyColl.Count; i++)
        {
            if (chckstring == keyColl.ElementAt(i).Key)
            {
                value = clrDatesSelectedSortedDict[keyColl.ElementAt(i).Key];
                if ((i + 1) < keyColl.Count)
                    nextValue = clrDatesSelectedSortedDict[keyColl.ElementAt(i + 1).key];
            }
        }
    }
