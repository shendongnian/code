    public static int ExtractIntProperty<T>( this T targetItem, string propertyName )
    {
    
       int result = 0;
    
       var prop = targetItem.GetType()
                            .GetProperties()
                            .FirstOrDefault( prp => prp.Name == propertyName );
    
    
       if (prop != null)
       {
          var val = prop.GetValue( targetItem, null );
    
          if (val != null)
             result = (int) val;
       }
    
       return result;
    
    }
