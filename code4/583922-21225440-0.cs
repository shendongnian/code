	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();
			SystemParameters.StaticPropertyChanged += this.SystemParameters_StaticPropertyChanged;
			
			// Call this if you haven't set Background in XAML.
			this.SetBackgroundColor();
		}
		protected override void OnClosed(EventArgs e)
		{
			SystemParameters.StaticPropertyChanged -= this.SystemParameters_StaticPropertyChanged;
			base.OnClosed(e);
		}
		private void SetBackgroundColor()
		{
			this.Background = SystemParameters.WindowGlassBrush;
		}
		private void SystemParameters_StaticPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "WindowGlassBrush")
			{
				this.SetBackgroundColor();
			}
		}
	}
