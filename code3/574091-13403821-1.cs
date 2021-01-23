    public MainWindow()
    {
        InitializeComponent();
        //Setting the Items property to a new list, will call the setter..
        bar.Items = new List<BarItem>
        {
            new BarItem { Lable = "Test1", Value = 500 }, 
            new BarItem { Lable = "Test2", Value = 1000 },
            new BarItem { Lable = "Test3", Value = 1500 }
        };
    }
