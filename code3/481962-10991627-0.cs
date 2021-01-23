    public MainPage()
    {
        InitializeComponent();
        MainPageVMProperty = new ViewModels.MainPageViewModel();
    }
    public ViewModels.MainPageViewModel MainPageVMProperty { get; set; }
    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        LayoutRoot.DataContext = MainPageVMProperty;
    }
