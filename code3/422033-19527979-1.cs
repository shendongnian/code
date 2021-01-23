    public View()
    {
      InitializeComponent();
      personList.ItemsSource = PersonDataSource.CreateList(100);
        Loaded += (sender, args) => Debug.WriteLine("Loaded");
    }
      protected override void OnNavigatedTo(NavigationEventArgs e)
      {
          Debug.WriteLine("Navigated");
      }
