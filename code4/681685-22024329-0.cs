    /// <summary>
    /// The denominator is stored in this altered form, because all struct fields initialize to 0 - and we want newly created RationalNumbers to be 0/1 more often than 0/0.
    /// </summary>
    private int _denominatorMinusOne;
    public int Denominator 
    { 
        get { return _denominatorMinusOne + 1; } 
        set { _denominatorMinusOne = value -1; } 
    }
