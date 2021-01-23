	public class MyView : UserControl
	{   
		private readonly Exception _ex;
		public MyView()
		{
			try { InitializeComponent(); } catch (Exception caught) { _ex = caught; } 
		}
		protected override OnDataContextChanged(object sender, EventArgs e)
		{
			if (_ex == null) return;
			var vm = view.DataContext as ErrorViewModel;
			if (vm != null)
			{
				vm.HandleInitializationException(view, caught);
				return;
			}
			throw new Exception("Error occurred during View initialization", _ex);
		}
	}
