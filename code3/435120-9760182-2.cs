    public IEnumerable<Int32> GetAllId()
    {
        return dict1.Values
                    .Select(x => x.GetId())
                    .Concat(dict2.Values.Select( x=> x.GetId()))
                    .Concat(dict3.Values.Select(x => x.GetId()))
                    .SelectMany(x => x);
    }
