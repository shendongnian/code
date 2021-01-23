    [DataMember(Name="Foo")]
    public string FormattedFoo {
        get { return /* apply some custom formatting to 'Foo' */; }
        set { Foo = /* apply some custom parsing to 'value' */; }
    }
    public DateTime Foo {get;set;}
