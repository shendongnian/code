    for ( Type t = typeof( Bar ) ; t != null ; t = t.BaseType )
    {
      MemberInfo[] members = t.GetMembers( BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public ) ;
      
      Console.WriteLine() ;
      Console.WriteLine( "Type {0}:" , t.FullName ) ;
      
      // enumerate the methods directly implemented by the type
      Console.WriteLine( "* Methods:" ) ;
      int memberCount = 0 ;
      foreach ( MethodInfo method in members.Where( x => x.MemberType == MemberTypes.Method ).Select( x => (MethodInfo)x ) )
      {
        ++memberCount ;
        Console.WriteLine("  - {0}( {1} )" , method.Name , string.Join(" , " , method.GetParameters().Select(p=>p.ParameterType.Name)) ) ;
      }
      if ( memberCount == 0 ) {  Console.WriteLine("  n/a" ) ; }
      
      // enumerate the properties directly implemented by the type
      Console.WriteLine( "* Properties:" ) ;
      int propertyCount = 0 ;
      foreach ( PropertyInfo property in members.Where( x => x.MemberType == MemberTypes.Property ).Select( x => (PropertyInfo)x ) )
      {
        ++propertyCount ;
        Console.WriteLine("  - {0}: {1}" , property.Name , property.PropertyType.FullName ) ;
      }
      if ( propertyCount == 0 ) {  Console.WriteLine("  n/a" ) ; }
    }
