    static void Fill<T>(IList<T> arrayOrList, T value)
    {
        for (int i = arrayOrList.Count - 1; i >= 0; i--)
        {
            arrayOrList[i] = value;
        }
    }
