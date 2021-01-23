    public string FirstString { get; set; }
    public string SecondString { get; set; }
    public string ThirdString { get; set; }
    public string FourthString { get; set; }
    public MainWindow()
    {
        InitializeComponent();    
        FirstString = "First";
        SecondString = "Second";
        ThirdString = "Third";
        FourthString= "Fourth";
        this.DataContext = this;  //here you set the context to current instance of window
    }
