    public Dictionary<string,List<Widget>> LoadWidgetDictionary( IEnumerable<Widget> widgets )
    {
      Dictionary<string,List<Widget>> instance = new Dictionary<string,List<Widget>>() ;
      
      foreach( Widget item in widgets )
      {
        List<Widget> accumulator ;
        bool         found       = instance.TryGetValue( item.Name , out accumulator ) ;
        
        if ( !found )
        {
          accumulator = new List<Widget>() ;
          instance.Add( item.Name , accumulator ) ;
        }
        
        accumulator.Add(item) ;
        
      }
      
      return ;
    }
