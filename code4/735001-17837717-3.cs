	// Read encoded file back to xml
	string enc_text = File.ReadAllText(@"C:\Temp\A.enc");
	Console.WriteLine(enc_text); // (Debug)
		
	// Pre encoding hex
	byte[] mem_bytes = Convert.FromBase64String(enc_text);
	Console.WriteLine(BitConverter.ToString(mem_bytes)); // (Debug)
	
	// XML Data
	Console.WriteLine(new UTF8Encoding().GetString(mem_bytes));
	// Read byte array into Reader
	using (var stream = new MemoryStream(mem_bytes))
	{
    	using (XmlReader reader = XmlReader.Create(stream))
    	{
        	// Use reader as desired
    	}
	}
