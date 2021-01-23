    public IEnumerable<Func<int>> Actions
    {
        get
        {
            List<Func<int>> list = new List<Func<int>>();
            list.Add( AddFunction );
            list.Add( SubstractFunction );
            return list;
        }
    }
