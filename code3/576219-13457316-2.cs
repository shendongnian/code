    void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			var dataGrid = new DataGrid();
			dataGrid.AutoGenerateColumns = false;
			// For each column you want
			var column1 = new DataGridTextColumn();
			column1.Header = "MyHeader";
			column1.Binding = new Binding("MyProperty");
			dataGrid.Columns.Add(column1);
			// LayoutRoot is the main grid of the Window
			this.LayoutRoot.Children.Add(dataGrid);
			// Let's test to see if the binding is working
			IEnumerable<DummyClass> testEnumerable = new List<DummyClass>(){
				new DummyClass(){MyProperty= "Element1"},
				new DummyClass(){MyProperty= "Element2"},
			};
			dataGrid.ItemsSource = testEnumerable;
		}
