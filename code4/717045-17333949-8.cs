    IEnumerable<IEnumerable<T>> Batches<T>(IEnumerable<T> input, int n)
    {
        var array = new T[n];
        int i = 0;
        foreach(var x in input)
        {
            array[i] = x;
            i = (i + 1) % n;
            if (i == 0)
            {
                yield return array.ToArray();
            }
        }
        if (i != 0)
        {
            yield return array.Take(i);
        }
    }
