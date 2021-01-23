    // Class record
    [DelimitedRecord("|")]
    public class MyClass
    {
        public string Field1 { get; set; }
        public int Field2 { get; set; }
        public string Field3 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // create some data to export
            MyClass[] rows = new MyClass[2] { 
              new MyClass() { Field1 = "Apples",  Field2 = 23, Field3 = "Yes" },
              new MyClass() { Field1 = "Oranges", Field2 = 17, Field3 = "No"} 
            };
            ExcelStorage provider = new ExcelStorage(typeof(MyClass));
            // Set the destination Excel spreadsheet
            provider.FileName = @"MyClass.xlsx";
            // Template.xlsx contains just the column headers on row 1
            provider.TemplateFile = @"Template.xlsx"; 
            // StartRow is after the header row
            provider.StartRow = 2; 
            
            provider.OverrideFile = true;
            provider.InsertRecords(rows);
        }
    }
