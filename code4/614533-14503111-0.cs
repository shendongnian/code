	namespace ConsoleApplication1
	{
		using System;
		using System.Reflection;
		internal class SimpleExample
		{
			public string Name { get; set; }
		}
		class Program
		{
			static void Main(string[] args)
			{
				var newItem = CreateObjectInstance("SimpleExample");
				if (newItem == null)
				{
					Console.WriteLine("Failed to create!");
				}
				else
				{
					Console.WriteLine("Successfully created!");
				}
				Console.ReadKey();
			}
			private static Object CreateObjectInstance(string strObjectName)
			{
				Object obj = null; // Temporary object
				try
				{
					if (strObjectName.LastIndexOf(".") == -1) // If there is no '.' in the object name
						strObjectName = Assembly.GetEntryAssembly().GetName().Name + "." + strObjectName;
					obj = Assembly.GetEntryAssembly().CreateInstance(strObjectName);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error instantiating the object\n\nDescription : " + ex.Message);
					obj = null;
				}
				return obj;
			}
		}
	}
