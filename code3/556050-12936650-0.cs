	var task = Task.Factory.StartNew(() =>
				                      {
					                      _host = new ServiceHost(typeof (MyService));
					                      _host.Open();
				                      };
			task.Wait();
			CheckHostIsAvailable();
