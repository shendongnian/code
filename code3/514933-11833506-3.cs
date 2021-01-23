    // Constructor
    public MainPage()
    {
        InitializeComponent();
        BackKeyPress += OnBackKeyPressed;
    }
    void OnBackKeyPressed(object sender, System.ComponentModel.CancelEventArgs e)
    {
        var result = MessageBox.Show("Do you want to exit?", "Attention!",
                                      MessageBoxButton.OKCancel);
        if (result == MessageBoxResult.OK)
        {
            // Do not cancel navigation
            return;
        }
        e.Cancel = true;
    }
