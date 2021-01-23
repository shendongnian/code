    	public static bool WaitforExit(this Action act, int timeout)
		{
			var cts = new CancellationTokenSource();
			var task = Task.Factory.StartNew(act, cts.Token);
			if (Task.WaitAny(new[] { task }, TimeSpan.FromMilliseconds(timeout)) < 0)
			{ // timeout
				cts.Cancel();
				return false;
			}
			else if (task.Exception != null)
			{ // exception
				cts.Cancel();
				throw task.Exception;
			}
			return true;
		}
