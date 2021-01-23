	void Main()
	{
		var fields = new List<Field>{
			new Field{Id = 1, Name = "A"},
			new Field{Id = 2, Name = "B"},
			new Field{Id = 3, Name = "C"},
		};
		
		// Makes a list of strings with comma separated fields		   
		var list_Of_CSV_Items = fields.Select(x => string.Join(",", x.Id,x.Name));
		
		System.IO.File.WriteAllLines(@"C:\WriteCommaSeparatedLines.txt", list_Of_CSV_Items);
		
	}
	
	public class Field
	{
		public int Id {get;set;}
		public string Name {get; set;}
	}
 
