    public static IEnumerable<T> Exchange<T>(
        this IEnumerable<T> source, int index1, int index2) 
    {
        if (index1 > index2)
        {
            int i = index1;
            index1 = index2;
            index2 = i;
        }
        int i = 0;
        List<T> itemsBetweenIndexes = new List<T>();
        bool queue = true;
        T temp;
        foreach(var item in source)
        {
            if (!queue)
            {
                if (i == index1)
                {
                    tmp = item;
                    queue = true;
                }
                else
                {
                    yield return item;
                }
            }
            else
            {
                if (i == index2)
                {
                    queue = false;
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
            i++;
        }
    }
