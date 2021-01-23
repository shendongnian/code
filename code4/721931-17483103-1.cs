    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Diagnostics;
 
	class MainClass
	{
		static string[] fileNames = Enumerable.Range(1, 80).Select(i => string.Format("file{0}.txt", i)).ToArray();
		public static void Main(string[] args)
		{
			var stopwatch = Stopwatch.StartNew();
			List<StreamReader> readers = fileNames.Select(f => new StreamReader(f)).ToList();
			try
			{
				using (StreamWriter writer = new StreamWriter("master.txt"))
				{
					string line = null;
					do
					{
						for(int i = 0; i < readers.Count; i++)
						{
							if ((line = readers[i].ReadLine()) != null)
							{
								writer.Write(line);
							}
							if (i < readers.Count - 1)
								writer.Write(",");
						}
						writer.WriteLine();
					} while (line != null);
				}
			}
			finally
			{
				foreach(var reader in readers)
				{
					reader.Close();
				}
			}
			Console.WriteLine("Elapsed {0} ms", stopwatch.ElapsedMilliseconds);
		}
	}
