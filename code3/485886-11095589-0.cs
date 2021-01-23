    public TimeStamp Foo {get;set;}
    [ProtoMember(n)]
    private long FooValue {
        get { return (long)Foo; }
        set { Foo = (TimeStamp)value; }
    }
