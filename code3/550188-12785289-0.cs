    public class EventList<T> : IList<T> /* NOTE: Changed your List<T> to IList<T> */
    {
      private List<T> list; // initialize this in your constructor.
      public event ListChangedEventDelegate ListChanged;
      public delegate void ListChangedEventDelegate();
      private void notify()
      {
          if (ListChanged != null
              && ListChanged.GetInvocationList().Any())
          {
            ListChanged();
          }
      }
      public new void Add(T item)
      {
          list.Add(item);
          notify();
      }
      public List<T> Items {
        get { return list; } 
        set {
          list = value; 
          notify();
        }
      }
      ...
    }
