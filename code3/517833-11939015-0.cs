    public class MyWidget
    {
      private IDictionary<int,string> _myKeyedCollection = GetMyCollection() ;
      private ReadonlyDictionary<int,string> _readOnlyWrapper = null ;
      public ReadonlyDictionary PubliclyExposedCollection
      {
        get
        {
          if ( _readOnlyWrapper == null ) _readOnlyWrapper = new ReadonlyDictionary<int,string>( _myKeyedCollection ) ;
          return _readOnlyWrapper ;
          
        }
      }
    }
