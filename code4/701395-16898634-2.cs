	public partial class UserControl1 : UserControl
	{
		public UserControl1()
		{
			InitializeComponent();
		}
		private void OnButtonClick(object sender, RoutedEventArgs e)
		{
			var viewModel = (RootViewModel)DataContext;
			var resultMessage = string.Format("{0} * {1} = {2}", viewModel.X, viewModel.Y, viewModel.XY);
			
			MessageBox.Show(resultMessage, "X * Y");
		}
	}
