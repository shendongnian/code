    interface IGenericType 
	{
	    void Method1();
	    void Method2();
	}
	
	class Dummy1: IGenericType
	{
		public void Method1() { Console.WriteLine("Dummy1.Method1()"); }
	    public void Method2() { Console.WriteLine("Dummy1.Method2()"); }
	}
	class Dummy2: IGenericType
	{
		public void Method1() { Console.WriteLine("Dummy2.Method1()"); }
	    public void Method2() { Console.WriteLine("Dummy2.Method2()"); }
	}
	
	static class Manager
	{
		private static Dictionary<Type, IGenericType> myTypes = new Dictionary<Type, IGenericType>();
		
		static Manager()
		{
			myTypes.Add(typeof(Dummy1), new Dummy1());
			myTypes.Add(typeof(Dummy2), new Dummy2());
		}
		
	   public static IGenericType GetManagableType<T>()
	   {
	   		if (myTypes.ContainsKey(typeof(T)))
	   		{
		   		return myTypes[typeof(T)];
	   		}
	   	
	   		throw new ArgumentException("Type is not a managable type.", "T");
	   }
	}
	class Program
	{
		public static void Main(string[] args)
		{
			Manager.GetManagableType<Dummy1>().Method1();
			Manager.GetManagableType<Dummy1>().Method2();
			Manager.GetManagableType<Dummy2>().Method1();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
