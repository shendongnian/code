    public MyEnumerationType Foo
    {
        get { return _foo; }
        set { 
               this._foo = (MyEnumerationType) value; 
               TriggerSomething(..);
           }
    }
