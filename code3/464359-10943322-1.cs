	public class AccessServiceAPI
	{
		private void MethodA(string mandatory, string mandatory2, string optional)
		{
			// do stuff
		}
		
		public class MethodABuilder
		{
			private string Mandatory { get; set; }
			private string Mandatory2 { get; set; }
			private string Optional { get; set; }
			
			public MethodABuilder( string mandatory, string mandatory2)
			{
				Mandatory = mandatory;
				Mandatory2 = mandatory;
				Optional = "default value";
			}
			
			public MethodABuilder Optional( string optional )
			{
				Optional = optional;
				return this;
			}
			
			public void Build()
			{
				MethodA(mandatory, mandatory2, optional);
			}
		}
	}
