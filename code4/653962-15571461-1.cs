	public class SomeClass {
		private SomeClass(int initParameter) {
			this.Property = initParameter; // Will always be executed, the logic exists once		
		}
		
		
		public SomeSerializableClass(int initParameter, string otherParameter)
			: this(initParameter)
		{
		}
		public SomeSerializableClass(int initParameter, int againAntherParameter)
			: this(initParameter)
		{
		}
		
		public int Property { get; set; }
	}
