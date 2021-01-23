    public DateTime OrderDate
    {
    	get { return (DateTime) GetValue(OrderDateProperty); }
    	set { SetValue(OrderDateProperty, value); }
    }
    
    public static readonly DependencyProperty OrderDateProperty =
    	DependencyProperty.Register("OrderDate",
    								typeof (DateTime),  
    								typeof (MainWindow),
    								new PropertyMetadata(DateTime.Now, // Default value for the property
    													 new PropertyChangedCallback(OnOrderDateChanged)));
    
    private static void OnOrderDateChanged(object sender, DependencyPropertyChangedEventArgs args)
    {
    	MainWindow source = (MainWindow) sender;
    
    	// Add Handling Code
    	DateTime newValue = (DateTime) args.NewValue;
    }
    public MainWindow()
    {
    	InitializeComponent();
    
    	OrderDateText.DataContext = this;
    	var binding = new Binding("OrderDate")
    		{
    			StringFormat = "dd-MM-yyyy"
    		};
    	OrderDateText.SetBinding(TextBox.TextProperty, binding);
    
    	//Testing
    	OrderDate = DateTime.Now.AddDays(2);
    
    }
