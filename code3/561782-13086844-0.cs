    public static class FileStreamExtensions
	{
		public static IEnumerable<string> SplitByChar(this StreamReader stream, char[] splitter)
		{
			int MAXREAD = 1024 * 1024;
			var chars = new List<char>(MAXREAD);
			var bytes = new char[MAXREAD];
			var lastStop = 0;
			var read = 0;
			while (!stream.EndOfStream)
			{
				read = stream.Read(bytes, 0, MAXREAD);
				lastStop = 0;
				for (int i = 0; i < read; i++)
				{
					if (bytes[i] == splitter[0])
					{
						var assume = true;
						for (int p = 1; p < splitter.Length; p++)
						{
							assume &= splitter[p] == bytes[i + p];
						}
						if (assume)
						{
							chars.AddRange(bytes.Skip(lastStop).Take(i - lastStop));
							
							var res = new String(chars.ToArray());
							chars.Clear();
							yield return res;
							i += splitter.Length - 1;
							lastStop = i + 1;
						}
					}
				}
				chars.AddRange(bytes.Skip(lastStop));
			}
			chars.AddRange(bytes.Skip(lastStop).Take(read - lastStop));
			yield return new String(chars.ToArray());
		}
	}
