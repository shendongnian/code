	using System;
	using System.ServiceModel;
	namespace Service
	{
		class Program
		{
			static void Main(string[] args)
			{
				try
				{
					using (var serviceHost = new ServiceHost(typeof(StreamService)))
					{
						serviceHost.Open();
						Console.WriteLine("Press Any Key to end");
						Console.ReadKey();
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}
		}
	}
