	public class SomeSerializableClass {
		private SomeSerializableClass() {} // Used only in serialization
		
		public SomeSerializableClass(int initParameter){
			this.Property = initParameter;
		}
		
		public int Property { get; set; }
	}
	public class Program{
		static void Main(){
			var obj1 = new SomeSerializableClass(42); // valid
			var obj2 = new SomeSerializableClass(); // invalid
			
			var xs = new XmlSerializer(typeof(SomeSerializableClass));
			var obj3 = (SomeSerializableClass)xs.Deserialize(someStream); // possible
		
		}
	}
	
	
