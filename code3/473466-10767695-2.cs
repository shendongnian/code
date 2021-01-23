    public CPrint() : this(100) 
    { 
    }
    public CPrint(int i) : this (Convert.ToString(i))
    {
    }
    public CPrint(string s)
    {
        sToPrint = s;
    }
