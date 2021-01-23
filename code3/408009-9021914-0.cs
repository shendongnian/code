    AutoResetEvent ev = new AutoResetEvent(false);
    // Called on a background thread
    void ThreadProc()
	{
		int lastProcessed = 0;
	    while (true)
		{
			// Perform our processing as before
			for (int i = lastProcessed; i < this.items.Count; i++)
			{
				this.ProcessItem(this.items[i]);
			}
			
			// We have processed all items currently in the list, wait for some more
			ev.WaitOne();
		}
	}
	
	void OnNewItems()
	{
	    ev.Set();
	}
