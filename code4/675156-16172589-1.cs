    using (FileStream fs = new FileStream(@"C:\bad_records.txt", FileMode.Create, FileAccess.Write))
    {
        var badEnumerable = _cache.Where(kvp => !kvp.Value.Item1);
    
		int count = 0;
        foreach (var item in badEnumerable)
        {
			count++;
            Console.WriteLine(string.Format("{0}: {1}", item.Key, item.Value.Item2));
        }
		
        Console.WriteLine("==========");
        Console.WriteLine(string.Format("BAD  RECORDS ({0})", count));
    }
