    public MainPage()
    {
        this.InitializeComponent();
        Window.Current.VisibilityChanged += Current_VisibilityChanged;
    }
    void Current_VisibilityChanged(object sender, Windows.UI.Core.VisibilityChangedEventArgs e)
    {
        if (!e.Visible) 
        {
            //Something useful
        }
    }
