    private string _foo;
    private string _bar;
    
    public string Foo
    {
       get { return _foo; }
       set {
          _foo = value;
          _bar = _foo.Substring(3, 5);
       }
    }
    
    public string Bar
    {
       get { return _bar; }
       set {
          _bar = value;
          _foo = "XXX" + _bar;
       }
    }
