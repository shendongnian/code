		static void Main(string[] args)
		{
			const int bufferSize = 1024 * 1024 * 2;
			var buffer = new byte[bufferSize];
			WeakReference wref = null;
			for(int i = 0; i < 10; i++)
			{
				if(wref != null)
				{
					// force garbage collection
					GC.Collect();
					GC.WaitForPendingFinalizers();
					GC.Collect();
					// check if object is still alive
					Console.WriteLine(wref.IsAlive); // true
				}
				const int writesCount = 400;
				using(var stream = new MemoryStream(writesCount * bufferSize))
				{
					for(int j = 0; j < writesCount; j++)
					{
						stream.Write(buffer, 0, buffer.Length);
					}
					// weak reference won't prevent garbage collection
					wref = new WeakReference(stream);
				}
			}
		}
