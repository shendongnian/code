		using (var memoryStream = new MemoryStream())
		using (var streamWriter = new StreamWriter(memoryStream))
		using (var csvWriter = new CsvWriter(streamWriter))
		{
			csvWriter.Configuration.RegisterClassMap(new MyClassMap(ClassType.TypeOdd));
			csvWriter.WriteRecords(records);
			streamWriter.Flush();
			return memoryStream.ToArray();
		}
