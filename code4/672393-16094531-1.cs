    static T FindMax<T>( this IEnumerable<T> items , Func<T,T,int> comparer  ) where T:class
    {
      T max = null ;
      foreach ( T item in items )
      {
        if ( item == null ) { continue ; }
        if ( max == null ) { max = item ; continue ; }
        
        // check current item against max.
        // if current item is "greater than" the current max
        // replace it.
        int cc = comparer(item,max) ;
        if ( cc > 0 )
        {
          max = item ;
        }
      }
      return max ;
    }
