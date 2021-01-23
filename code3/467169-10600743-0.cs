    public class Locations 
    {
      private Dictionary<string, object> _values;
      public Locations() 
      {
        _values = new Dictionary<string, object>();
      }
      public void Set(string propertyName, object value)
      {
         if(!_values.ContainsKey(propertyName))
            _values.Add(propertyName, value);
         else
            _values[propertyName] = value;
      }
      public object Get(string propertyName)
      {
         return _values.ContainsKey(propertyName) ? _values[propertyName] : null;
      }
    
      public string CountryCode
      {
         get{ return Get("CountryCode"); }
         set{ Set("CountryCode", value); }
      }
    }
