    class Widget
    {
      static Widget()
      {
        StaticWidgetProperty = int.MinValue ;
        return ;
      }
      public Widget( int x )
      {
        this.InstanceWidgetProperty = x ;
        return ;
      }
      public static int StaticWidgetProperty   { get ; set ; }
      public        int InstanceWidgetProperty { get ; set ; }
    }
    
    class Program
    {
      static void Main()
      {
        Widget myWidget = new Widget(-42) ;
        
        setStaticProperty<int>( typeof(Widget) , "StaticWidgetProperty" , 72 ) ;
        setInstanceProperty<int>( myWidget , "InstanceWidgetProperty" , 123 ) ;
        
        return ;
      }
      
      static void setStaticProperty<PROPERTY_TYPE>( Type type , string propertyName , PROPERTY_TYPE value )
      {
        PropertyInfo propertyInfo = type.GetProperty( propertyName , BindingFlags.Public|BindingFlags.Static , null , typeof(PROPERTY_TYPE) , new Type[0] , null ) ;
        
        propertyInfo.SetValue( null , value , null ) ;
        
        return ;
      }
      
      static void setInstanceProperty<PROPERTY_TYPE>( object instance , string propertyName , PROPERTY_TYPE value )
      {
        Type type = instance.GetType() ;
        PropertyInfo propertyInfo = type.GetProperty( propertyName , BindingFlags.Instance|BindingFlags.Public , null , typeof(PROPERTY_TYPE) , new Type[0] , null ) ;
        
        propertyInfo.SetValue( instance , value , null ) ;
        
        return ;
      }
      
    }
