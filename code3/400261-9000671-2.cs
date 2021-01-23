	class Program
	{
		static void Main()
		{
			AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
			RealMain();
		}
		static void RealMain()
		{
			new Class1();
		}
		
		static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
		{
			Console.WriteLine("! " + args.LoadedAssembly.FullName);
		}
	}
