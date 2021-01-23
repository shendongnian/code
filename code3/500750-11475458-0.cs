			webClient.DownloadDataAsync(myUri);
			webClient.DownloadDataCompleted += (s, e) =>
			                                   {
			                                   	tcs.TrySetResult(e.Result);
			                                   };
			if (wait)
			{
				tcs.Task.Wait();
				Console.WriteLine("got {0} bytes", tcs.Task.Result.Length);
			}
			else
			{
				tcs.Task.ContinueWith(t => Console.WriteLine("got {0} bytes", t.Result.Length));
			}
