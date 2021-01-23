    public class Dto
    {
        public DateTime dateTime { get; set; }
        public Int32 Unit { get; set; }
        public String Message { get; set; }
    }
    
    
    public List<Dto> GetEnumerableObject()
    {
    
           //Populate your Datatable from Excel Spreadsheet here as your already doing
    
    
           Var Result = (from rows in DataTable.AsEnumerable()
    
                         select new Dto
                         {
                            dateTime = rows.Field<DateTime>("date"),
                            Unit = rows.Field<Int32>("unit"),
                            Message = rows.Field<string>("message")
                         }).ToList();
           return Result;
    
    }
