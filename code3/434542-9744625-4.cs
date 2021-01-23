    Dictionary<string,string> LoadDictionaryFromFile( string fileName )
    {
      Dictionary<string,string> instance = new Dictionary<string,string>() ;
      
      using ( TextReader tr = File.OpenText( fileName ) )
      {
        for ( string line = tr.ReadLine() ; line != null ; line = tr.ReadLine() )
        {
          string key   ;
          string value ;
          
          parseLine( line , out key , out value ) ;
          addToDictionary( instance , key , value );
          
        }
      }
      
      return instance ;
    }
    
    void parseLine( string line , out string key , out string value )
    {
      if ( string.IsNullOrWhiteSpace(line) ) throw new InvalidDataException() ;
      string[] words = line.Split( ',' ) ;
      
      if ( words.Length != 2 ) throw new InvalidDataException() ;
      
      key   = words[0].Trim() ;
      value = words[1].Trim() ;
      
      if ( string.IsNullOrEmpty( key   ) ) throw new InvalidDataException() ;
      if ( string.IsNullOrEmpty( value ) ) throw new InvalidDataException() ;
      
      return ;
    }
    
    private static void addToDictionary( Dictionary<string , string> instance , string key , string value )
    {
      string existingValue;
      bool   alreadyExists = instance.TryGetValue( key , out existingValue );
      
      if ( alreadyExists )
      {
        // duplicate key condition: concatenate new value to the existing value,
        // or display error message, or throw exception, whatever.
        instance[key] = existingValue + '/' + value;
      }
      else
      {
        instance.Add( key , value );
      }
      return ;
    }
