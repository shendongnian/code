    void Main()
    {
    	var file = @"C:\...location.of.file...\p022_names.txt";
    	using (var reader = new StreamReader(file, Encoding.UTF8))
    	{
        	NameScore(reader.ReadToEnd().Replace("\"",string.Empty).Split(new[]{','})).Dump();	
    	}
    }
    
    private long NameScore(string[] names)
    {
    	return names.OrderBy(o => o)
                    .Select((l, i) => { return l.ToUpper().ToCharArray().Sum(s => (int)s - 64) * (i + 1);})
                    .Sum(s => s);
    }
