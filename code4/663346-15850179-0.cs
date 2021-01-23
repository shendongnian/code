				public static string Path1;
				public static string Path2;
				public static string Path3;
		 
				public void ReadConfig(string txtFile)
				{
				    using (StreamReader sr = new StreamReader(txtFile))
				    {
					var dict = new Dictionary<string, string>();
					string line;
					while (!string.IsNullOrEmpty((line = sr.ReadLine())))
					{
								dict = File.ReadAllLines(txtFile)
							   .Select(l => l.Split(new[] { '=' }))
							   .ToDictionary( s => s[0].Trim(), s => s[1].Trim());
					}
					Path1 = dict["PathOne"];
					Path2 = dict["PathTwo"];
					Path3 = Path1 + @"\Test";
				    }
				}
