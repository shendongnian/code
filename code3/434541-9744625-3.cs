    public Dictionary<string,Widget> LoadWidgets( IEnumerable<Widget> widgets )
    {
      Dictionary<string,Widget> instance = new Dictionary<string,Widget>() ;
      
      foreach ( Widget item in widgets )
      {
        if ( instance.ContainsKey( item.Name ) )
        {
          DisplayDuplicateItemErrorMessage() ;
        }
        else
        {
          instance.Add( item.Name , item ) ;
        }
      }
      return instance ;
    }
