    				var item = NextQueuedItem;
				if (item != null)	// Item can be missing if woken up when the worker is being cleaned up and closed.
				{
					Console.WriteLine(string.Format("Worker processing item: {0}", item.Data));
					_waitHandle.Reset();
				}
