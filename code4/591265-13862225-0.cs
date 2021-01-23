    public class STElement
    {
      public int _value;
      public STElement _next;
      public int _index;
    
      public STElement()
      {
        _value = 0;
        _next = null;
        _index = 0;
      }
      public STElement(int index)
          : this()
      {
         _index = index;
      }
    }
    _rootStack1 = new STElement(1);
    _rootStack2 = new STElement(2);
    _rootStack3 = new STElement();
