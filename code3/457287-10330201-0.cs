	interface IRequest 
	{
		string Header { get; set; }
		string Request1 { get; set; }
	}
	[DataContract]
	class SimpleRequest : IRequest
	{
		[DataMember]
		public string Header { get; set; }
		
		[DataMember(Name="SimpleRequest1"]
		public string Request1 { get; set; }
	}
	[DataContract]
	class ComplexRequest : IRequest
	{
		[DataMember]
		public string Header { get; set; }
		
		[DataMember(Name="ComplexRequest1"]
		public string Request1 { get; set; }
	}
