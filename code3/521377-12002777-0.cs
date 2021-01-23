		static void Main(string[] args)
		{
			const int bufferSize = 1024 * 1024 * 2;
			var buffer = new byte[bufferSize];
			for(int i = 0; i < 10; i++)
			{
				const int writesCount = 400;
				Write(buffer, writesCount, bufferSize);
			}
		}
		static void Write(byte[] buffer, int writesCount, int bufferSize)
		{
			using(var stream = new MemoryStream(writesCount * bufferSize))
			{
				for(int j = 0; j < writesCount; j++)
				{
					stream.Write(buffer, 0, buffer.Length);
				}
			}
		}
