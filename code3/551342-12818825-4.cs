	public class Downloader
	{
		ConcurrentQueue<Uri> _queue = new ConcurrentQueue<Uri>();
		int _maxWorkers = 10;
		long _currentWorkers = 0;
		ManualResetEvent _completed;
		
		public void Enqueue(Uri uri)
		{
			_queue.Enqueue(uri);
			if (Interlocked.Read(_currentWorkers)  < _maxWorkers)
			{
				// not very thread safe, but we just want to limit the workers
				// within a reasonable limit. 1 or 2 more doesn't really matter.
				Interlocked.Increment(_currentWorkers);
				
				// yes, i'm a bit old fashioned.
				TriggerJob();
			}
		}
		
		private void TriggerJob()
		{
			Uri uri;
			if (!_queue.TryDequeue(out uri))
			{
				Interlocked.Decrement(_currentWorkers);
				return;
			}
			
			var client = new WebClient();
			client.Encoding = Encoding.UTF8;
			client.DownloadDataCompleted += DownloadDataCompleted;
			client.DownloadDataAsync(uri);
		}
		
		private void DownloadDataCallback(object sender, DownloadDataCompletedEventArgs e)
		{
			try
			{
				// If the request was not canceled and did not throw 
				// an exception, display the resource. 
				if (!e.Cancelled && e.Error == null)
				{
					var args = new DownloadedEventArgs { uri = e.Uri, data = (byte[])e.result};
					DownloadCompleted(this, args)
				}
				else
				{
					var args = new DownloadFailedEventArgs { uri = e.Uri, error = e.Error };
					DownloadFailed(this, args);
				}
			}
			catch (Exception err)
			{
				var args = new DownloadFailedEventArgs { uri = e.Uri, error = err };
				DownloadFailed(this, args);
			}
			
			TriggerJob();
		}
		
		public event EventHandler<DownloadedEventArgs> DownloadCompleted = delegate{};
		public event EventHandler<DownloadFailedEventArgs> DownloadFailed = delegate{};
		
	}
	public class DownloadedEventArgs
	{
		public Uri uri;
		public byte[] data;
	}
	public class DownloadFailedEventArgs
	{
		public Uri uri;
		public Exception error;
	}
