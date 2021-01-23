    private readonly bool?[] _boolArray = new bool?[5];
    // Your properties
    public bool? Intubated_1
    {
        get
        {
            return _boolArray[0];
        }
        set
        {
            _boolArray[0] = value;
        }
    }
    public bool? Intubated_2
    {
        get
        {
            return _boolArray[1];
        }
        set
        {
            _boolArray[1] = value;
        }
    }
    // Count
    public int CountNonNull
    {
        get
        {
            return _boolArray.Count(i => i != null);
        }
    }
