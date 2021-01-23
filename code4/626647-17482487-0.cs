    private string _foo;
    private string _bar;
    public Foo
    {
       get;
       set {
          if (_foo != value)
          {
             _foo = value;
             Bar = _foo.Substring(3, 5);
          }
       }
    }
    public Bar
    {
       get;
       set {
          if (_bar != value)
          {
             _bar = value;
             Foo = "XXX" + _bar;
          }
       }
    }
