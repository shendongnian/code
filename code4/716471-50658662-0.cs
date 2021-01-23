	public class LogModule : NancyModule
	{
		public LogModule()
		{
			Get["/log"] = GetLog;
		}
    	private object GetLog(object args)
		{
			return new Response
			{
				ContentType = "text/event-stream",
				Contents = stream =>
				{
					while (true)
					{
						Thread.Sleep(1000);
						var json = JsonConvert.SerializeObject(new Log("Test"));
						if (!TrySendEvent(json, stream))
							break;
					}
				}
			};
		}
		private static bool TrySendEvent(string value, Stream stream)
		{
			try
			{
				var data = Encoding.UTF8.GetBytes("data: " + value + "\n\n");
				stream.Write(data, 0, data.Length);
				stream.Flush();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
