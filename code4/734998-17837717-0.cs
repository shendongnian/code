	using (var ms = new MemoryStream())
	{	
        // Memory Stream
		using (XmlWriter writer = XmlWriter.Create(ms,settings)) 
		{
			writer.WriteStartDocument();
			writer.WriteStartElement("Database");
			writer.WriteStartElement("Entry");
			writer.WriteAttributeString("key", "value");
			writer.WriteEndElement();
			writer.WriteEndElement();
			
			writer.Flush();
			writer.Close();
			
			// XML Data (Debug)
			Console.WriteLine(new UTF8Encoding().GetString(ms.ToArray()));
			
			// Pre encoding hex (Debug)
			Console.WriteLine(BitConverter.ToString(ms.ToArray()));
			
			string s = Convert.ToBase64String(ms.ToArray());
			Console.WriteLine(s); // (Debug)
			// Post encoding
			File.WriteAllText(@"C:\Temp\A.enc", s);
		}
	}
	
