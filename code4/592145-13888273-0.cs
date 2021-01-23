    public FinanceItemViewControl()
    {
        this.InitializeComponent();
        detailPageDataModel = new ExpenseDetailPageDataModel(Month);
        this.Loaded += UserControl_Loaded;
    }
    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine("Constructor: " + Month);
    }
