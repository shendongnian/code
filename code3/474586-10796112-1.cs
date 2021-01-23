    	void modi()
		{
			if(!Dispatcher.CheckAccess())
			{
				Dispatcher.Invoke(DispatcherPriority.Normal, 
						()=>label1.Content = "df" );
			}
			else
			{
				label1.Content = "df";
			}
		}
