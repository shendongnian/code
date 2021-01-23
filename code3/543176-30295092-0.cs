    public MySubWindow()
    {
        if ((base.Owner = Application.Current.MainWindow) == null)
            throw new Exception();
        InitializeComponent();
    }
