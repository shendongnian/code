    public event FooChangedHandler FooChanged;
    protected void OnFooChanged(Foo)
    {
      var temp = FooChanged;
      if (temp != null)
      {  
        temp(new FooChangedEventArgs(Foo));
      }
    }
