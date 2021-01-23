    using(var sStreamReader = new StreamReader(@"d:\\TEST.txt"))
    {
    	string sLine;
    	while ((sLine = sStreamReader.ReadLine()) != null)
    	{
    		if (string.IsNullOrEmpty(sLine)) continue;
    
    		var rows = sLine.Split(",".ToCharArray());
    		var a = Convert.ToDouble(rows[1]);
    		Console.Write(a);
    		var b = Convert.ToInt32(rows[3]);
    		Console.WriteLine(b);
    		Console.WriteLine();
    	}
    }
