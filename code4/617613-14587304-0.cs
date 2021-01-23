    using(Stream stream = File.Open("file.txt", FileMode.Open))
        			{
        				StreamReader reader = new StreamReader(stream);
        				string text = reader.ReadToEnd();
        				var groups = text.GroupBy(x => x);
        
        				foreach (var group in groups)
        				{
        					Console.WriteLine(string.Format("{0} : {1}", group.Key, group.Count()));
        				}
    			}
