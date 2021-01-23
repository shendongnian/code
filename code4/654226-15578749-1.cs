	class Program
	{
		[ModuleInitializer("ClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "ClassLibrary1.dll", "ModuleInitializerTest", "ModuleInitialize")]
		static void Main(string[] args)
		{
			Console.WriteLine("Loaded assemblies:");
			var asms = AppDomain.CurrentDomain.GetAssemblies();
			foreach (var assembly in asms)
			{
				Console.WriteLine("\tAssembly Name:{0}", assembly.GetName());
				var mods = assembly.GetModules();
				foreach (var module in mods)
				{
					Console.WriteLine("\t\tModule Name:{0}", module.Name);
				}
			}
			// This should trigger the load of the ClassLibrary1 assembly
			aReference();
			Console.ReadLine();
		}
		static void aReference()
		{
			var foo = new SomeOtherClass();			
		}
	}
