    private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			lblStatus.Visibility = Visibility.Visible;
			Task.Factory.StartNew(()=>
				{
					Foo.Validate();
					OnUi(() => lblStatus.Visibility = Visibility.Hidden);
				}
			};
		}
    
    public static void OnUi (Action action)
    {
        if (_dispatchService == null) _dispatchService = ServiceLocator.Current.GetInstance<IDispatchService>();
         if (_dispatchService.CheckAccess())
				action.Invoke ();
			else
                _dispatchService.Invoke(action);
		}
