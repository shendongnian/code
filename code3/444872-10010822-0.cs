    foreach( var memberInfo in members )
    {
      propertyInfo = types.GetProperty( memberInfo.Name );
      if( propertyInfo != null )
      {
         Console.WriteLine( propertyInfo.PropertyType ); 
         // type of every property
      }
    }
