    static void Main()
    {
                
        var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("People");
    
        var people = new List<Person>
        {
            new Person{Name = "John Doe", DOB = new DateTime(1980,1,1)},
            new Person{Name = "Jane Doe", DOB = new DateTime(1985,1,1)}
        };
    
        ws.FirstCell().InsertTable(people);
    
        ws.Columns().AdjustToContents();
        wb.SaveAs(@"C:\MyFiles\Excel Files\Sandbox.xlsx");
    }
    
    class Person
    {
        [Display(Name = "Person's Name")]
        public String Name { get; set; }
                
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
    }
