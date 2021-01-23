    public static Dictionary<TKey, TValue> deepCopyDic<TKey, TValue>(Dictionary<TKey, TValue> src)
        where TValue : ICloneable
    {
        //Copies a dictionary with all of its elements
        //RETURN:
        //      = Dictionary copy
        Dictionary<TKey, TValue> dic = new Dictionary<TKey, TValue>();
        foreach (var item in src)
        {
            dic.Add(item.Key, (TValue)item.Value.Clone());
        }
        return dic;
    }
