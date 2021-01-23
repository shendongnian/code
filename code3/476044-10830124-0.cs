    public MainWindow()
		{
			InitializeComponent();
			this.Activated += new EventHandler(MainWindow_Activated);
		}
		void MainWindow_Activated(object sender, EventArgs e)
		{
			if (m == null)
				return;
			m.Activate();
		}
		
		private void button1_Click(object sender, RoutedEventArgs e)
		{
			m = new MyDialog();
			m.ShowDialog();
		}
		MyDialog m;
		
