	using System;
	using System.Management;
	
	namespace Test
	{
		class Program
		{
			public static void Main(string[] args)
			{
				string query = string.Format("SELECT * from Win32_Printer");
				ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
				ManagementObjectCollection coll = searcher.Get();
	
				foreach (ManagementObject printer in coll)
				{
				    //foreach (PropertyData property in printer.Properties)
				    //{
				    //    Console.WriteLine(string.Format("{0}: {1}", property.Name, property.Value));
				    //}
				    
				    var property = printer.Properties["DriverName"];
				    if (property.Value.ToString().ToLowerInvariant().Contains("zebra"))
				    {
				    	Console.ForegroundColor = ConsoleColor.Red;
				    	Console.Write("ZEBRA: ");
				    }
				    else 
				    {
				    	Console.ForegroundColor = ConsoleColor.Gray;
				    	Console.Write("Regular: ");
				    }
	
			    	Console.WriteLine(string.Format("{0}: {1}", property.Name, property.Value));
				}
	
				Console.Write("Press any key to continue . . . ");
				Console.ReadKey(true);
			}
		}
	}
