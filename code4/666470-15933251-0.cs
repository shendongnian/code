    private int? _PageNumber = null;
    
    public int? PageNumber
    {
        get { return _PageNumber; }
        set { _PageNumber = value; }
    }
    
    if (string.Empty != "")
    {
        PageNumber = Convert.ToInt32(string.Empty);
        Console.WriteLine("Setting to value.");
    }
    else
    {
        PageNumber = null;
        Console.WriteLine("Setting to NULL.");
    }
