    private decimal? _data1;
    public decimal? data1
    {
        get
        {
            if (_data1.HasValue)
                return _data1;
            // This needs System.Linq but can be done manually.
            return children.Sum(c => c.data1);
        }
        set { _data1 = value; }
    }
