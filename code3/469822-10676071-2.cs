    public class MyClass
    {
    
      private readonly Dictionary<string, string> _myColl = new Dictionary<string, string>();
    
      public Dictionary<string, string> Items
      { 
        get { return this._myColl; }
      }
    
    }
