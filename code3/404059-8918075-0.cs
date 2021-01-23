	using (var writer = new StreamWriter(stream))
	{
		writer.Write(xml.ToString());
		writer.Flush();
		// writer.Close() can be called here, but is automatically called at the end of the using block
	}
