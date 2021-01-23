	using System;
	using System.IO;
	using Client.Service;
	namespace Client
	{
		class Program
		{
			static void Main(string[] args)
			{
				try
				{
					using (StreamClient streamClient = new StreamClient())
					{
						streamClient.Open();
						using (FileStream fileStream = new FileStream("c:\\temp\\bigfile.exe",FileMode.Create))
						{
							streamClient.GetLargeObject().CopyTo(fileStream);    
						}
					}
					Console.WriteLine("Press any key to end");
					Console.ReadKey();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
			}
		}
	}
