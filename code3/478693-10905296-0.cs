	using System;
	using System.IO;
	namespace test_data
	{
		class Program
		{
			static string drive = Path.GetPathRoot(Environment.CurrentDirectory);
			static void CrawlDir(string dir)
			{
				foreach (string subDir in Directory.GetDirectories(dir))
				{
					try
					{
						Console.WriteLine(subDir);
						CrawlDir(subDir);
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
				}
			}
			static void Main(string[] args)
			{
				CrawlDir(drive);
				Console.ReadLine();
			}
			
		}
	}
