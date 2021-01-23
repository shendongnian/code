	private void AddLog(string logItem)
			{
				this.Dispatcher.BeginInvoke((MethodInvoker) delegate
				{
					this.Log.Add(new KeyValuePair<string, string>(DateTime.Now.ToLongTimeString(), logItem));
				});
			}
