    public class User
    {
      	[CsvColumn(FieldIndex = 1)]
       	public string UserName { get; set; }
	
        [CsvColumn(FieldIndex = 2)]
       	public string Dept { get; set; }
        [CsvColumn(FieldIndex = 3)]
       	public string Name { get; set; }
    }
