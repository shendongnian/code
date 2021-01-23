	//used to store converted data
	Dictionary<string, string> data = new Dictionary<string, string>();
	//open file, read line by line and store values as needed
	using (TextReader tr = File.OpenText("test.txt"))
	{
		//throw away header line
		string line = tr.ReadLine();
		while ((line = tr.ReadLine()) != null)
		{
			string[] values = line.Split(new char[] { ' ', '\t' });
			string key = values[values.Length - 1];
			if (data.ContainsKey(key))
				data[key] += "/" + values[0];
			else
				data.Add(key, values[0]);
		}
	}
	//print results
	foreach (string date in data.Keys)
		Console.WriteLine(String.Format("Annual {0} Update: {1}", data[date], date));
