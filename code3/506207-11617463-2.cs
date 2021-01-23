	private void button1_Click(object sender, RoutedEventArgs e)
	{
		ColorAnimation ca = new ColorAnimation(Colors.Blue, new Duration(TimeSpan.FromSeconds(4)));
		this.Background = new SolidColorBrush(Colors.Red);
		this.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
	}
