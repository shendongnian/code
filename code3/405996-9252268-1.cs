    private void UserControl_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
	{
		((Storyboard)FindResource("sbMain")).Stop();
	}
	private void UserControl_Loaded(object sender, RoutedEventArgs e)
	{
			((Storyboard)FindResource("sbMain")).Begin();
	}
