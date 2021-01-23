    public class Repository : IStorage<Widget>
    {
      private IDictionary<string,Widget> backingStore = new Dictionary<string,Widget>() ;
      
      public Widget this[string id]
      {
      get
        {
          Widget instance ;
          bool   exists   = backingStore.TryGetValue(id, out instance ) ;
          return instance ; // null if the dictionary doesn't contain the key
        }
      set
        {
          if ( string.IsNullOrWhiteSpace(id) ) throw new ArgumentException("id") ;
          if ( value == null                 ) throw new ArgumentNullException("value") ;
          backingStore.Add( id , value ) ;
          return ;
        }
      }
    }
