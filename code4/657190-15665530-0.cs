    static void Main( string[] args )
    {
      Dictionary<string,object> nested = LoadNestedDictionary() ;
      Dictionary<string,string> flat   = new Dictionary<string, string>() ;
      Flatten(nested,flat) ;
      return;
    }
    
    /// <summary>
    /// The wrapper method. Invoke this from your code
    /// </summary>
    /// <param name="input"></param>
    /// <param name="output"></param>
    private static void Flatten( IEnumerable<KeyValuePair<string,object>> input , Dictionary<string,string> output )
    {
      foreach ( KeyValuePair<string,object> item in input )
      {
        string key   = item.Key   ;
        object value = item.Value ;
        if ( value is string )
        {
          output.Add(key,(string)value) ;
        }
        else if ( value is Dictionary<string,object> )
        {
          Flatten( key , (IEnumerable<KeyValuePair<string,object>>) value , output ) ;
        }
        else
        {
          throw new InvalidOperationException();
        }
      }
      return ;
    }
    
    /// <summary>
    /// The core method. Called only from the wrapper method
    /// </summary>
    /// <param name="root"></param>
    /// <param name="input"></param>
    /// <param name="output"></param>
    private static void Flatten( string root , IEnumerable<KeyValuePair<string,object>> input , Dictionary<string,string> output )
    {
      foreach ( KeyValuePair<string,object> item in input )
      {
        string segment = item.Key ;
        string key     = root + "." + segment ;
        object value   = item.Value ;
        if ( value is string )
        {
          string s = (string) value ;
          output.Add(key,s) ;
        }
        else if ( value is Dictionary<string,object> )
        {
          Dictionary<string,object> d = (Dictionary<string,object>) value ;
          Flatten(key,d,output);
        }
        else
        {
          throw new InvalidOperationException();
        }
      }
      return ;
    }
