    	class Program
	{
		static void Main(string[] args)
		{
			string xmlConfig = "";
			string jsonConfig = "";
			Config myConfig = new Config()
			{
				value = "My String Value",
				DateStamp = DateTime.Today,
				counter = 42,
				Id = Guid.NewGuid()
			};
			// Make both strings
			DataContractSerializer xmlSerializer = new DataContractSerializer(typeof(Config));
			using (MemoryStream xmlStream = new MemoryStream())
			{
				xmlSerializer.WriteObject(xmlStream, myConfig);
				xmlConfig = Encoding.UTF8.GetString(xmlStream.ToArray());
			}
			DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Config));
			using (MemoryStream jsonStream = new MemoryStream())
			{
				jsonSerializer.WriteObject(jsonStream, myConfig);
				jsonConfig = Encoding.UTF8.GetString(jsonStream.ToArray());
			}
			// Test Single
			var XmlSingleTimer = Stopwatch.StartNew();
			SerializeXML(xmlConfig, 1);
			XmlSingleTimer.Stop();
			var JsonSingleTimer = Stopwatch.StartNew();
			SerializeJSON(jsonConfig, 1);
			JsonSingleTimer.Stop();
			// Test 1000
			var XmlTimer = Stopwatch.StartNew();
			SerializeXML(xmlConfig, 1000);
			XmlTimer.Stop();
			var JsonTimer = Stopwatch.StartNew();
			SerializeJSON(jsonConfig, 1000);
			JsonTimer.Stop();
			// Test 10000
			var XmlTimer2 = Stopwatch.StartNew();
			SerializeXML(xmlConfig, 10000);
			XmlTimer2.Stop();
			var JsonTimer2 = Stopwatch.StartNew();
				SerializeJSON(jsonConfig, 10000);
			JsonTimer2.Stop();
			Console.WriteLine(String.Format("XML Serialization Single: {0} ticks", XmlSingleTimer.ElapsedTicks));
			Console.WriteLine(String.Format("JSON Serialization Single: {0} ticks", JsonSingleTimer.ElapsedTicks));
			Console.WriteLine();
			Console.WriteLine(String.Format("XML Serialization 1000: {0} ms", XmlTimer.ElapsedMilliseconds));
			Console.WriteLine(String.Format("JSON Serialization 1000: {0} ms ", JsonTimer.ElapsedMilliseconds));
			Console.WriteLine();
			Console.WriteLine(String.Format("XML Serialization 10000: {0} ms ", XmlTimer2.ElapsedMilliseconds));
			Console.WriteLine(String.Format("JSON Serialization 10000: {0} ms ", JsonTimer2.ElapsedMilliseconds));
		}
		public static void SerializeXML(string xml, int iterations)
		{
			DataContractSerializer xmlSerializer = new DataContractSerializer(typeof(Config));
			for (int i = 0; i < iterations; i++)
			{
				using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
				{
					Config serialized = (Config)xmlSerializer.ReadObject(stream);
				}
			}
		}
		public static void SerializeJSON(string json, int iterations)
		{
			DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Config));
			for (int i = 0; i < iterations; i++)
			{
				using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
				{
					Config serialized = (Config)jsonSerializer.ReadObject(stream);
				}
			}
		}
	}
	public class Config
	{
		public string value;
		public DateTime DateStamp;
		public int counter;
		public Guid Id;
	}
