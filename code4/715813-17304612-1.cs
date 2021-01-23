    private void SingleSelectedMeasurement(object sender, RoutedEventArgs e)
    {
        var button = (System.Windows.Controls.Button)sender;
        
        Task.Factory.StartNew (
           () => OnUi(RedrawSingelMeasurement(Convert.ToInt16(button.Tag))));        
    }
    //here's a sample on how to get despatcher for the ui thread
    private void OnUi (Action action)
		{
            if (_dispatchService == null) 
                _dispatchService = ServiceLocator.Current.GetInstance<IDispatchService>();
                //or _dispatchService  = Application.Current.Dispatcher - whatever is suitable
            if (_dispatchService.CheckAccess())
				action.Invoke ();
			else
                _dispatchService.Invoke(action);
		}
