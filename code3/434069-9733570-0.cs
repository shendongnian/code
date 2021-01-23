    public int Foo {get;set;} // automatically implemented property
    public string bar;
    public string Bar { // manually implemented property
        get { return bar; }
        set { bar = value; }
    }
