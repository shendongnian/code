    public class Base
    {
      private List<DoSomething> _myEventStorage;
      public event DoSomething myEvent
      {
        add
        {
          _myEventStorage.Insert(0, value);
        }
        remove
        {
          _myEventStorage.Remove(value);
        }
      }
    ...
      public void EventFired()
      {
        var args = new ChainEventArgs();
        foreach (var handler in _myEventStorage)
        {
          handler(this, args);
          if (args.Handled)
            break;
        }
      }
    }
