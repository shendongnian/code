    public AddFooLevel( Levels level, string name, Foo foo ) {
      IDictionary<string,Foo> level = null;
      if( _foos.ContainsKey( level ) ) {
        level = _foos[level];
      } else {
        level = new Dictionary<string,Foo>();
        _foos.Add( level );
      }
      level.Add( name, foo );
    }
      
