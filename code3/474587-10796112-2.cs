    	void modi()
		{
			if(!Dispatcher.CheckAccess())
			{
				Dispatcher.Invoke(
						()=>label1.Content = "df",DispatcherPriority.Normal);
			}
			else
			{
				label1.Content = "df";
			}
		}
