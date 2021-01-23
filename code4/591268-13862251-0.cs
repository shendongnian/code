     public STElement()
      {
        _value = 0;
        _next = null;
        _index = 0;
      }
    
     public STElement(int param1)
      {
        _value = param1;
        _next = null;
        _index = 0;
      }
     public STElement(int param1, int param2):this()
      {
        _value = param1;
        _next = null;
        _index = param2;
      }
...
