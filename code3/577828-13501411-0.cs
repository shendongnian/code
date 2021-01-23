    public void FetchAndLoad()
		{
            // Called from the UI, run in the ThreadPool
			Task.Factory.StartNew( () =>
			this.FetchAsync(e => this.Dispatcher.InvokeAsync(
				() => this.observableCollection.Add(e)
				)
			));
		}
		public void Fetch(Action<string> addDelegate)
		{
                        // Dummy operation
			var list = new List<string>("Element1", "Element2");
			foreach (var item in list)
				addDelegate(item);
		}
