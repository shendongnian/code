    public SomeView(IViewModel vm)
	{
		ViewModel = vm;
		DataContext = ViewModel;
		InitializeComponent();
		ViewModel.PropertyChanged += (s, e) =>
		{
			switch (e.PropertyName)
			{
				case "IsResetingColumns":
					if (!ViewModel.IsResetingColumns)
					{
						dataGrid.ItemsSource = null;
						dataGrid.ItemsSource = ViewModel.Resources;
					}
					break;
				}
			};
		}
