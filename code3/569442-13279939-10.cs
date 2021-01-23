    class Test
	{
		public static object RunWithTimeout<T>(Func<T,object> act, int timeout, T obj) where T : IDisposable
		{
			object result = null;
			Thread thread = new Thread(() => { 
				try { result = act(obj); }
				catch {}	// this is where we end after timeout...
			});
			thread.Start();
		    if (!thread.Join(timeout))
			{
		        obj.Dispose();
				thread.Join();
			}
			return result;
		}
		
		public void SocketTimeout(int timeout)
		{
			using (var sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
	      	{
				Object res = RunWithTimeout(EntryPoint, timeout, sock);
			}
		}
		
		private object EntryPoint(Socket sock)
		{
			var buf = new byte[256];
			sock.Receive(buf);
			return buf;
		}
	}
  
