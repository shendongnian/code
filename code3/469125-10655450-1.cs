		foreach (XElement xE in xD.Descendants("elem"))
		{
			//Console.WriteLine(xE.Attribute("attr").Value);
			if (xE.Attribute("attr") != null)
			{
				Console.WriteLine(xE.Attribute("attr").Value);
				if (xE.Attribute("attr").Value.EndsWith("AA"))
				{
					Console.WriteLine("match");
					xE.Attribute("attr").Value = xE.Attribute("attr").Value.Replace("AA", "");
				}
				Console.WriteLine(xE.Attribute("attr").Value);
			}
		}
