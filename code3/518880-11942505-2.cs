		XmlSerializer xs = new XmlSerializer(typeof(DecimalField));
		
		string serializedXml = null;
		using (StringWriter sw = new StringWriter())
		{
			DecimalField df = new DecimalField() { Value = 12.0M, Estimate = false };
			xs.Serialize(sw, df);
			serializedXml = sw.ToString();
		}
		
		Console.WriteLine(serializedXml);
		
		using (StringReader sr = new StringReader(serializedXml))
		{
			DecimalField df = (DecimalField)xs.Deserialize(sr);
			
			Console.WriteLine(df.Estimate);
			Console.WriteLine(df.Value);
		}
