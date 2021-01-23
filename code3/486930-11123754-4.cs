	public static class Helper
	{
		public static IComparable GetDeleteMapCommand(DependencyObject obj)
		{
			return (IComparable)obj.GetValue(DeleteMapCommandProperty);
		}
		public static void SetDeleteMapCommand(DependencyObject obj, IComparable value)
		{
			obj.SetValue(DeleteMapCommandProperty, value);
		}
		public static readonly DependencyProperty DeleteMapCommandProperty =
			DependencyProperty.RegisterAttached("DeleteMapCommand", typeof(IComparable), typeof(Helper), new UIPropertyMetadata(null, OnDeleteMapCommandChanged));
		private static void OnDeleteMapCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			//when we attach the command, grab a reference to the control
			var mapControl = sender as MapControl;
			if (mapControl == null) return;
			//and the command
			var command = GetDeleteMapCommand(sender);
			if (command == null) return;
			//then hook up the event handler
			mapControl.Deleting += (o,e) =>
			{
				if (command.CanExecute(e.Maps))
					command.Execute(e.Maps);
			};
		}
	}
