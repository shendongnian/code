	private static readonly Random _random = new Random();
	private static void PropBChanged(DependencyObject lDependencyObject, DependencyPropertyChangedEventArgs lDependencyPropertyChangedEventArgs)
	{
		((MainWindow)lDependencyObject).PropA = _random.Next().ToString();
	}
	private static void PropAChanged(DependencyObject lDependencyObject, DependencyPropertyChangedEventArgs lDependencyPropertyChangedEventArgs)
	{
		((MainWindow)lDependencyObject).PropB = _random.Next().ToString();
	}
