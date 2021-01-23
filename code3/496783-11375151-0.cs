	private static void OnPointsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		MyUserControl control = d as MyUserControl;
		IEnumerable newCollection = e.NewValue as IEnumerable;
		control._points = new ObservableCollection<DataPoint>(newCollection.Cast<DataPoint>());
	}
