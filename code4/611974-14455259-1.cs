    public partial class CustomWindowStyle : Window
	{
		public CustomWindowStyle()
		{
			this.InitializeComponent();
		}
		private void BtnMax_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.WindowState = WindowState.Maximized;
		}
		private void BtnMin_Click(object sender, System.Windows.RoutedEventArgs e)
		{			
			this.WindowState = WindowState.Minimized; 
		}
		private void BtnClose_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();
		}		
	}
