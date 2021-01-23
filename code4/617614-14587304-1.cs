    byte[] bytes = System.IO.File.ReadAllBytes("file.txt");
			var groups = bytes.GroupBy(x => x);
			foreach (var group in groups)
			{
				Console.WriteLine(string.Format("{0} : {1}", group.Key, group.Count()));
			}
			Console.ReadLine();
