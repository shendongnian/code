    public partial class MainWindow: Window
    {
        public ObservableCollection<LogRecord> Records { get; private set; }
        public static RoutedUICommand SignOutCommand { get; private set; }
		
		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			Records = new ObservableCollection<LogRecord>();
			CreateDemoData();
			SignOutCommand = new RoutedUICommand();
			CommandBinding cb = new CommandBinding(SignOutCommand, OnSignOut, OnCanSignOut);
			this.CommandBindings.Add(cb);
		}
		private void CreateDemoData()
		{
			for (int i = 0; i < 5; i++)
			{
				Records.Add(new LogRecord());
			}
		}
		private void OnCanSignOut(object sender, CanExecuteRoutedEventArgs e)
		{
			var record = e.Parameter as LogRecord;
			e.CanExecute = record != null && !record.ExitTime.HasValue;
		}
		private void OnSignOut(object sender, ExecutedRoutedEventArgs e)
		{
			var record = e.Parameter as LogRecord;
			if (record == null) return;
			record.ExitTime = DateTime.Now;
		}
	}
