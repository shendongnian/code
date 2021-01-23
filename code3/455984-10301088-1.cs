    // Constructor
		public MainPage()
		{
			InitializeComponent();
			// Set the data context of the listbox control to the sample data
			DataContext = App.ViewModel;
			this.Loaded += new RoutedEventHandler(MainPage_Loaded);
		}
		// Load data for the ViewModel Items
		private void MainPage_Loaded(object sender, RoutedEventArgs e)
		{
			pvcontrol.SelectedIndex = 1;
			if (!App.ViewModel.IsDataLoaded)
			{
				App.ViewModel.LoadData();
			}
		}
