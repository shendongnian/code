    public MainWindow()
    {
    	InitializeComponent();
    
    	StackPanel stackpanel = new StackPanel(); 
    	stackpanel.MouseEnter += new MouseEventHandler(stackpanel_MouseEnter);
    	stackpanel.MouseLeave += new MouseEventHandler(stackpanel_MouseLeave);
    }
    
    void stackpanel_MouseLeave(object sender, MouseEventArgs e)
    {
    	StackPanel stackpanel = (StackPanel)sender;
    	stackpanel.Background = Brushes.Transparent;
    }
    
    void stackpanel_MouseEnter(object sender, MouseEventArgs e)
    {
    	StackPanel stackpanel = (StackPanel)sender;
    	stackpanel.Background = Brushes.LightGray;
    }
