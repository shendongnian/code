    var dispatcher = Dispatcher.CurrentDispatcher;
    var loadTask = new Task( () =>
		{
			Image image = YourMethodThatLoadsImagesFromFB();
			if ( dispatcher.CheckAccess() )
			{
				YourMethodWhichProcessesReceivedImages( image );
			}
			else
			{
				dispatcher.BeginInvoke( YourMethodWhichProcessesReceivedImages, image);
			}
		} );
    loadTask.Start();
