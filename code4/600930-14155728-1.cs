				//Declare a new BackgroundWorker
				BackgroundWorker worker = new BackgroundWorker();
				worker.DoWork += (o, ea) =>
				{
					try
					{
						// Call your device
						
						// If ou need to interact with the main thread
					   Application.Current.Dispatcher.Invoke(new Action(() => //your action));
					}
					catch (Exception exp)
					{
					}
				};
				//This event is raise on DoWork complete
				worker.RunWorkerCompleted += (o, ea) =>
				{
					//Work to do after the long process
					disableGui = false;
				};
				disableGui = true;
				//Launch you worker
				worker.RunWorkerAsync();
