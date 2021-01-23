    public static IEnumerable<T> Exchange<T>(
        this IEnumerable<T> source, int index1, int index2) 
    {
        if (index1 > index2)
        {
            int x = index1;
            index1 = index2;
            index2 = x;
        }
        
        int index = 0;
        List<T> itemsBetweenIndexes = new List<T>();
        bool betweenIndexes = false;
        T temp = default(T);
        foreach(var item in source)
        {
            if (!betweenIndexes)
            {
                if (index == index1)
                {
                    temp = item;
                    betweenIndexes = true;
                }
                else
                {
                    yield return item;
                }
            }
            else
            {
                if (index == index2)
                {
                    betweenIndexes = false;
                    yield return item;
                    foreach(var x in itemsBetweenIndexes)
                    {
                        yield return x;
                    }
                    itemsBetweenIndexes.Clear();
                    yield return temp;
                }
                else
                {
                    itemsBetweenIndexes.Add(item);
                }
            }
    
            index++;
        }
    }
