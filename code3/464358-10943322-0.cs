	public class AccessServiceAPI
	{
		private void MethodA(string mandatory, string mandatory2, string optional)
		{
			// do stuff
		}
		
		public Class MethodABuilder
		{
			private string _mandatory = string.Empty;
			private string _mandatory2 = string.Empty;
			private string _optional = "default_value";
			
			public MethodABuilder( string mandatory, string mandatory2)
			{
				this._mandatory = mandatory;
				this._mandatory2 = mandatory;
			}
			
			public MethodABuilder Optional( string optional )
			{
				this._optional = optional;
				return this;
			}
			
			public void Build()
			{
				MethodA(mandatory, mandatory2, optional);
			}
		}
	}
