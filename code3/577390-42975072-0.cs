    public static int OrderedDictIndexOfKey(string key, OrderedDictionary oDict)
    {
        int i = 0;
        foreach (DictionaryEntry oDictEntry in oDict)
        {
            if ((string)oDictEntry.Key == key) return i;
            i++;
        }
        return -1;
    }
    public static object OrderedDictKeyAtIndex(int index, OrderedDictionary oDict)
    {
        if (index < oDict.Count && index >= 0)
        {
            return oDict.Cast<DictionaryEntry>().ElementAt(index).Key;
        }
        else
        {
            return null;
        }
    }
