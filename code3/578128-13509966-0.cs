		System.Windows.Controls.DataGrid dataGrid = new System.Windows.Controls.DataGrid();
		
		public void Initialize()
		{
			dataGrid.Loaded += new System.Windows.RoutedEventHandler(dataGrid_Loaded);
			dataGrid.Unloaded += new System.Windows.RoutedEventHandler(dataGrid_Unloaded);
			// Show image right away.
			this.dataGrid_Unloaded(null, null);
		}
		void dataGrid_Unloaded(object sender, System.Windows.RoutedEventArgs e)
		{
			// Provide some image here.
			dataGrid.Background = new System.Windows.Media.ImageBrush();
		}
		void dataGrid_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			dataGrid.Background = System.Windows.Media.Brushes.Gray;
		}
