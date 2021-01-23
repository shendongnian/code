    	void modi()
		{
			if(!Dispatcher.VerifyAccess())
			{
				Dispatcher.Invoke(DispatcherPriority.Normal, 
						()=>label1.Content = "df" );
			}
			else
			{
				label1.Content = "df";
			}
		}
