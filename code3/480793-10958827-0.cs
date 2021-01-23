    public class Settings
    {
       private static Settings _current;
       private static readonly object _lock = new object();
    
       public Settings Current
       {
          get
          {
             lock(_lock)
             {
                if (_current == null) throw new InvalidOperationException("Settings uninitialized");
                return _current;
             }
          }
          set
          {
              if (value == null) throw new ArgumentNullException();
              if (_settings != null) throw new InvalidOperationException("Current settings can only be set once.");
    
              if (_settings == null)
              {
                  lock(_lock)
                  {
                     if (_settings == null) _settings = value;
                  }
              }
          }
       }
        
    
       public string ImportantData { get; private set; }
    
       // etc. 
    }
