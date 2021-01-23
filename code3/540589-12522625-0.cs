    class Widget
    {
      public Widget( bool truthiness )
      {
        this.Truthiness = truthiness ;
      }
      public bool Truthiness { get ; private set ; }
    }
    
    class FooBar
    {
      private Widget[] Widgets { get ; private set; }
      
      private Widget[] GetSomeWidgets()
      {
          throw new NotImplementedException() ;
      }
      public FooBar()
      {
        Widgets = GetSomeWidgets() ;
      }
      private void WorkOnWidgets()
      {
        throw new NotImplementedException() ;
      }
      
      public void MakeEqual()
      {
        bool areEqual ; // zero or one widget and it's not a problem
        while ( !(areEqual=CheckIfAllWidgetsEqual()) )
        {
          WorkOnWidgets() ;
        }
        return ;
      }
      
      public bool CheckIfAllWidgetsEqual()
      {
        bool value = true ;
        if ( Widgets.Length > 1 )
        {
          Widget first        = Widgets[0] ;
          Widget firstUnequal = Widgets.Skip(1).FirstOrDefault( x => x.Truthiness != first.Truthiness ) ;
          value = firstUnequal != null ;
        }
        return value ;
      }
    
    }
