    public static Dictionary<TKey, TValue> deepCopyDic<TKey, TValue>(Dictionary<TKey, TValue> src)
        where TValue : ICloneable
    {
        //Copies a dictionary with all of its elements
        //RETURN:
        //      = Dictionary copy
        Dictionary<TKey, TValue> dic = new Dictionary<TKey, TValue>();
        for (int i = 0; i < src.Count; i++)
        {
            dic.Add(src.ElementAt(i).Key, (TValue)src.ElementAt(i).Value.Clone());
        }
        return dic;
    }
