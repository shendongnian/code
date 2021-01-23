        			IEBrowser.Navigate(url);
				bool flag = true;
				int times = 0;
				while (flag)
				{
					Sleep(500);
					Application.DoEvent();
					
					if (IEBrowser.ReadyState == WebBrowserReadyState.Complete)
					{
						times ++;
					}
					else
					{
						times = 0;
					}
					
					if (times >= 10)
					{
						flag = false;
					}
				}
				string str = IEBrowser.DocumentText;
        
