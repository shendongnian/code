    ViewModel m_ViewModel;
    public MainWindow()
    {
        InitializeComponent();
        DataContext = m_ViewModel = new ViewModel();
    }
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        m_ViewModel.Populate();
    }
