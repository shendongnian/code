    public partial class MyControl: UserControl
    {
      public CoalParameterGrid( )
      {
        InitializeComponent( );
      }
    
      public static DependencyProperty DarkBackgroundProperty = DependencyProperty.Register( "DarkBackground", typeof( Brush ), typeof( MyControl) );
    
      public Brush DarkBackground
      {
        get
        {
          return (Brush)GetValue( DarkBackgroundProperty );
        }
        set
        {
          SetValue( DarkBackgroundProperty, value );
        }
      }
    }
