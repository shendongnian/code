	[DataContract]
	public class Test
	{
		[DataMember]
		[DefaultValue(false)]
		public bool AllowNegative { get; set; }
	}
	void Main()
	{
		var sb2 = new StringBuilder();
		var dcs = new DataContractSerializer(typeof(Test));
		
		using(var writer = XmlWriter.Create(sb2))
		{
			dcs.WriteObject(writer, new Test());
		}
		
		Console.WriteLine(sb2.ToString());  
	}
