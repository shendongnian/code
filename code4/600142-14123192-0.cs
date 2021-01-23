    public MainPage()
    {
        InitializeComponent();
       
        for (int i = 0; i < 2; i++)
        {
            CheckBox c = new CheckBox();
            c.Content = " Value " ;
            lbox.Items.Add(c);
        }
    }
