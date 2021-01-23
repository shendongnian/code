    object s;
    public object Object
    {
        get { return s == null ? new object() : s; }
        set { s = value; }
    }
