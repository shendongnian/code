		private static readonly object Locker = new object();
		static void Main(string[] args)
		{
			for (int i = 0; i < 100; i++)
			{
				new Thread(new ThreadStart(DoSomeWork)).Start();
			}
		}
		static void DoSomeWork()
		{
			/*
			 
			 * Here you will build log messages
			 
			 */
			Log("192.168.1.15", "alive");
		}
		static void Log(string hostname, string state)
		{
			lock (Locker)
			{
				var doc = new XmlDocument();
				if (File.Exists("logs.txt"))
					doc.Load("logs.txt");
				else
				{
					var root = doc.CreateElement("hosts");
					doc.AppendChild(root);
				}
				var el = (XmlElement)doc.DocumentElement.AppendChild(doc.CreateElement("host"));
				el.SetAttribute("Hostname", hostname);
				el.AppendChild(doc.CreateElement("State")).InnerText = state;
				doc.Save("logs.txt");
			}
		}
