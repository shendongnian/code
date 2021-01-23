    class MyClass
    {
      private event EventHandler MyPrivateEvent;
    
      public event EventHandler MyEvent
      {
        add
        {
          MyPrivateEvent += value;
        }
        remove
        {
          MyPrivateEvent -= value;
        }
      }
    }
