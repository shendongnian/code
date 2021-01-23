    public MainPage()
    {
        InitializeComponent();
    
        this.MouseLeftButtonDown += OnMouseDown;
    }
    
    private void OnMouseDown( object sender, MouseButtonEventArgs e )
    {
        Point pos = e.GetPosition( this );
    
        double half = this.ActualWidth / 2;
    
        if( pos.X < half )
        {
            MyStackPanel.HorizontalAlignment = HorizontalAlignment.Right;
        }
        else
        {
            MyStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
        }
    }
