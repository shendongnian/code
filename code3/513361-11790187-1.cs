    using(var reader = new StreamReader(@"d:\\TEST.txt"))
    {
    	string line;
    	while ((line= reader.ReadLine()) != null)
    	{
    		if (string.IsNullOrEmpty(line)) continue;
    
    		var rows = line.Split(",".ToCharArray());
    		var a = Convert.ToDouble(rows[1]);
    		Console.Write(a);
    		var b = Convert.ToInt32(rows[3]);
    		Console.WriteLine(b);
    		Console.WriteLine();
    	}
    }
