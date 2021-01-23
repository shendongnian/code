	private static readonly TimeSpan timeoutPeriod = new TimeSpan(100000); // 10ms
	private const string filename = "Output.txt";
	public void WriteData(string data)
	{
		StreamWriter writer = null;
		DateTime timeout = DateTime.Now + timeoutPeriod;
		try
		{
			do
			{
				try
				{
					// Try to open the file.
					writer = new StreamWriter(filename);
				}
				catch (IOException)
				{
					// If this is taking too long, throw an exception.
					if (DateTime.Now >= timeout) throw new TimeoutException();
					// Let other threads run so one of them can unlock the file.
					Thread.Sleep(0);
				}
			}
			while (writer == null);
			writer.WriteLine(data);
		}
		finally
		{
			if (writer != null) writer.Dispose();
		}
	}
