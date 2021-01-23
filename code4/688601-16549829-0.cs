    public void CopyFrom(NameValueCollection a, Func<string, TKey> keyConvert, Func<string, TValue> valueConvert)
    {
        foreach(var k in a.AllKeys)
        {
             dict.Add(keyConvert(k), valueConvert(a[k]));
        }
    }
