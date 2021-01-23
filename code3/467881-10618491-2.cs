		public static void DoStuff(string inputFilePath, string outputFilePath, string lineToRemove)
		{
			using (StreamReader reader = new StreamReader(inputFilePath))
			using (StreamWriter writer = new StreamWriter(outputFilePath))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					if (!String.Equals(line, lineToRemove, StringComparison.CurrentCultureIgnoreCase))
						writer.WriteLine(line);
				}
			}
		}
