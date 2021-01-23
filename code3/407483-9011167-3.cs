    [Export]
	public partial class TestShell : RibbonWindow
	{
		public TestShell()
		{
			InitializeComponent();
			CommandManager.RegisterClassCommandBinding(typeof(TestShell), new CommandBinding(ApplicationCommands.Close, CloseApplicationExecuted));
		}
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
			MessageBox.Show("Not closing 1!");
		}
		private static void CloseApplicationExecuted(object sender, ExecutedRoutedEventArgs args)
		{
			RibbonWindow window = sender as RibbonWindow;
			if (window != null)
			{
				MessageBox.Show("Not closing 2!");
				args.Handled = true;
			}
		}
	}
