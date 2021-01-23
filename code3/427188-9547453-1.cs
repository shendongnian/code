    	public partial class MainPage : UserControl
	{
		public MainPage()
		{
			InitializeComponent();
		}
		private My_ViewModel _viewModel
		{
			get { return this.DataContext as My_ViewModel; }
		}
		private void firstButton_Click(object sender, RoutedEventArgs e)
		{
			this._viewModel.MyStoryboard.Begin();
		}
	}
