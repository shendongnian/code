	interface IManagementRole 
	{
	}
	
	class Dummy1: IManagementRole
	{
		public void Method1() { Console.WriteLine("Dummy1.Method1()"); }
		public void Method2() { Console.WriteLine("Dummy1.Method2()"); }
	}
	class Dummy2: IManagementRole
	{
		public void Method3() { Console.WriteLine("Dummy2.Method3()"); }
	    public void Method4() { Console.WriteLine("Dummy2.Method4()"); }
	}
	
	static class Manager
	{
		private static Dictionary<Type, IManagementRole> myTypes = new Dictionary<Type, IManagementRole>();
		
		static Manager()
		{
			myTypes.Add(typeof(Dummy1), new Dummy1());
			myTypes.Add(typeof(Dummy2), new Dummy2());
		}
		
		public static T GetManagableType<T>() where T: class
		{
			if (myTypes.ContainsKey(typeof(T)))
			{
				return myTypes[typeof(T)] as T;
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
			Manager.GetManagableType<Dummy2>().Method3();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
