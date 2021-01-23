    void CrossMap<T>(IEnumerable<T> enumerable)
    {
        List<T> myList = enumerable.ToList();
        for (int i = 0; i < myList.Count - 1; ++i)
        {
            for (int j = i+1; j < myList.Count; ++j)
            {
                DoMyStuff(myList[i], myList[j]);
            }
        }
    }
