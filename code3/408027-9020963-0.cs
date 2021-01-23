		protected override void OnStart(string[] args)
		{
			try
			{
				ABC abc = new ABC("www.abc.com");
				// Create the thread object, passing in the abc.Read() method
				Thread oThread = new Thread(new ThreadStart(abc.Read));
				// Start the thread
				oThread.Start();
			}
			catch (Exception)
			{
			}
		}
		public class ABC
		{
			string strUrl = "";
			public ABC(string url)
			{
				strUrl = url;
			}
			public void Read()
			{
				bool done = false;
				while (!done)
				{
					try
					{
						//Code to use the connectionurl to access a remote server
						//Use strUrl in here
					}
					catch (Exception)
					{
						//Wait 10 seconds before trying again
						Thread.Sleep(10000);
					}
					//On success, set done to true
					done = true;
				}
			}
		}
