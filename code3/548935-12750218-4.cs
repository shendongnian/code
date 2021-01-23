    public SwitchBrowser(CiscoSwitch cs)
    {
        SwitchViewModel svm = new SwitchViewModel(cs);
        DataContext = svm;
        InitializeComponent();
     }
