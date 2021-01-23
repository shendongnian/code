		public struct MyData
		{
			public string Name { set; get; }
		}
		public MainWindow()
		{
			InitializeComponent();
			ObservableCollection<MyData> oc = new ObservableCollection<MyData> { new MyData(), new MyData() };
			grid.ItemsSource = oc;
		}
		private void Grid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
		{
			var col = new DataGridTextColumn();
			Style myStyle = new Style(typeof(TextBox));
			// subsribe to TextChanged event
			myStyle.Setters.Add(new EventSetter(TextBoxBase.TextChangedEvent, new TextChangedEventHandler(OnTextChanged)));
			col.EditingElementStyle = myStyle;
			var binding = new Binding("Name") {Mode = BindingMode.TwoWay};
			col.Binding = binding;
			e.Column = col;
		}
		private static void OnTextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox textBox = sender as TextBox;
			BackgroundWorker worker = new BackgroundWorker();
			worker.DoWork += Worker_DoWork;
			worker.RunWorkerAsync(textBox);
			worker.RunWorkerCompleted += Worker_RunWorkerCompleted;          
		}
		static void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			TextBox textBox = e.Result as TextBox;
			if (textBox != null)
			{
				textBox.Text = textBox.Text.ToUpper();
				textBox.CaretIndex = textBox.Text.Length;
			}
		}
		static void Worker_DoWork(object sender, DoWorkEventArgs e)
		{
			Thread.Sleep(1);// This is the trick :)
			e.Result = e.Argument;
		}
