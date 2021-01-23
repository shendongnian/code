	myDispatchder.BeginInvoke(
		System.Windows.Threading.DispatcherPriority.Render,
		new Action(() =>
		{
			lock(objLocker)
			{
				// ..code..
			}
		}));
