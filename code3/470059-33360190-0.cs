	public class Place
	{
		public string name { get; set; }
		public int age { get; set; }
		public string name1 { get; set; }
		public string name2 { get; set; }
	}
	public class Detail
	{
		public string state { get; set; }
		public List<Place> place { get; set; }
	}
	public class Root
	{
		public List<Detail> details { get; set; }
	}
    public class Program 
    {
        static void Main(string[] args) 
    	{ 
    		string txt = File.ReadAllText("MyJSONFile.txt"); 
    		JavaScriptSerializer ser = new JavaScriptSerializer(); 
    		var data = ser.Deserialize<Root>(txt); 
            Console.WriteLine(data.details.Count); // 3
            Console.WriteLine(data.details[0].state); // myState1
            Console.WriteLine(data.details[1].place.Count); // 1
            Console.WriteLine(data.details[1].place[0].age); // 13
    	}
    }
