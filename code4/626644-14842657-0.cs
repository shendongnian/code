    private string _foo;
    private string _bar;
    
    public void set_Foo(string value)
    {
       _foo = value;
       set_Bar(_foo.Substring(3, 5));
    }
    
    public void set_Bar(string value)
    {
       _bar = value;
       set_Foo("XXX" + _bar);
    }
