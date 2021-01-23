    void Main()
    {
    	List<testdata> data = new List<testdata>();
    	Directory.GetFiles(@"C:\").ToList().ForEach(x=>data.Add(new testdata(){file=x,returnable=1}));
    	data.Where(x=>x.file.Contains("g")).Select(x=>x.file).Dump();
    }
    
    class testdata
    {
    	public string file {get; set;}
    	public string returnable {get; set;}
    }
