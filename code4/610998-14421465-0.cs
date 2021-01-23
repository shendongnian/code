	public static IObservable<byte[]> ObservableRead(Stream stream, int bufferSize)
	{
		return Observable.Create<byte[]>(o =>
		{
			var buffer = new byte[bufferSize];
			var read = 0;
			try
			{
				while (true)
				{
					read = stream.Read(buffer, 0, buffer.Length);
					if (read == 0)
					{
						break;
					}
					var results = buffer.Take(read).ToArray();
					//Always return a copy
					//never the buffer for concurrency's sake.
					o.OnNext(results);
				}
			}
			catch (Exception ex)
			{
				o.OnError(ex);
			}
			finally
			{
				o.OnCompleted();
			}
			return Disposable.Empty;
		});
	}
