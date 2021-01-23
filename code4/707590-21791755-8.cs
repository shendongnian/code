    public Test(string s): this(int.Parse(s))
    {
        if (s == null)
            throw new ArgumentNullException("s");
        Contract.EndContractBlock();
    }
