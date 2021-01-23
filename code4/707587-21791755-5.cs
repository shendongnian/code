    public Test(string s)
        : this(int.Parse(s))
    {
        Contract.Requires(s != null);
    }
