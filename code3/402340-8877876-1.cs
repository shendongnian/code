    public static IEnumerable<T[]> Windowed<T>(this IEnumerable<T> list, int windowSize)
    {
        //Checks elided
        var arr = new T[windowSize];
        int r = windowSize - 1, i = 0;
        using(var e = list.GetEnumerator())
        {
            while(e.MoveNext())
            {
                arr[i] = e.Current;
                i = (i + 1) % windowSize;
                if(r == 0) 
                    yield return ArrayInit<T>(windowSize, j => arr[(i + j) % windowSize]);
                else
                    r = r - 1;
            }
        }
    }
    public static T[] ArrayInit<T>(int size, Func<int, T> func)
    {
        var output = new T[size];
        for(var i = 0; i < size; i++) output[i] = func(i);
        return output;
    }
