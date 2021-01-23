    public void set_Foo(string value)
    {
       set_Bar(value.Substring(3, 5));
    }
    
    public void set_Bar(string value)
    {
       set_Foo("XXX" + value);
    }
