    public IAmImmutable(string member1, string member2)
    {
        this._Member1 = member1;
        this._Member2 = member2;
    }
    private readonly string _Member1;
    private readonly string _Member2;
    public string Member1 { get {return _Member1;} }
    public string Member2 { get {return _Member2;} }
