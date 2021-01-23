    public static XElement newXElementOrNull<T>( string name, T val ) {
       if ( typeof(T) == typeof(String) && val.ToString() == String.Empty ) {
          return null;
       }
       if ( EqualityComparer<T>.Default.Equals( val, default( T ) ) ) {
          return null;
       }
       else {
          return new XElement( name, val );
       }
    }
