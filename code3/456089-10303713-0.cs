           var files = Directory.GetFiles();
           var orderedFiles = files.OrderBy(s=>int.Parse( s));
			
			foreach (string s in orderedFiles)
			{
				Console.WriteLine(s);
			}
