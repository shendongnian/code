	namespace Example.SubFolder
	{
		internal class frmAdmAbout
		{
			public string Name { get; set; }
		}
	}
	namespace Example.ActualApp
	{
		using System;
		using System.Reflection;
		internal class Program
		{
			static void Main(string[] args)
			{
				var newItem = CreateObjectInstance("Example.SubFolder.frmAdmAbout");
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
				Object obj = null;
				try
				{
					if (strObjectName.LastIndexOf(".") == -1)
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
