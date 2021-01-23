    OrderedDictionary od = new OrderedDictionary();
	Dictionary<String, String> d = new Dictionary<String, String>();
	Random r = new Random();
	
	for (int i = 0; i < 10; i++)
	{
		od.Add("key"+i,"value"+i);
		d.Add("key"+i,"value"+i);
		if(i % 3 == 0)
		{
			od.Remove("key"+r.Next(d.Count));
			d.Remove("key"+r.Next(d.Count));
		}
	}
	
	System.Console.WriteLine("OrderedDictionary");
	foreach (DictionaryEntry de in od) {
		System.Console.WriteLine(de.Key +", " +de.Value);
	}
	
	System.Console.WriteLine("Dictionary");
	foreach (var tmp in d) {
		System.Console.WriteLine(tmp.Key +", " + tmp.Value);
	}
