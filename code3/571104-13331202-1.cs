	namespace MyApplication
	{
		using ExternalAssembly;
		
		public class CallInternalTest() 
		{
			MyClass classInstance = new MyClass();
			MyClass2 class2Instance = new MyClass2();
			
			// this will fail since hiddenString is an internal variable
			Console.WriteLine(classInstance.hiddenString);
			
			// this will succeed since Exposed is a public member
			Console.WriteLine(classInstance.Exposed);
			
			// this will also succeed since Exposed2 is a public member
			Console.WriteLine(class2Instance.Exposed2);
		}
	}
