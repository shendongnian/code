    public bool CompareNameValueCollections(NameValueCollection nvc1,
                                            NameValueCollection nvc2)
    {
        return nvc1.AllKeys.OrderBy(key => key)
                           .SequenceEqual(nvc2.AllKeys.OrderBy(key => key))
            && nvc1.AllKeys.All(key => nvc1[key] == nvc2[key]);
    }
