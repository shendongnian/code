    public class Csv : IDisposable
	{
		private StreamReader streadReader;
		private StreamWriter streamWriter;
		public void Dispose()
		{
			if (streadReader != null)
			{
				streadReader.Dispose();
			}
			if (streamWriter != null)
			{
				streamWriter.Dispose();
			}
		}
	}
