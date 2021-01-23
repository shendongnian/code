    public MainPage()
    {
        InitializeComponent();
        for (int i = 0; i < 2; i++)
        {
            lbox.Items.Add(new CheckBox{Content =" Value "});
        }
    }
