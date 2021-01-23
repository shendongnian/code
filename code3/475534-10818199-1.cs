    Regex g = new Regex(@"data-RowKey=(?<Value>\d+)");
	using (StreamReader r = new StreamReader("myFile.txt"))
	{
	    string line;
	    while ((line = r.ReadLine()) != null)
	    {
			Match m = g.Match(line);
			if (m.Success)
			{
				string v = m.Groups["Value"].Value;
				// ...
			}
	    }
	}
