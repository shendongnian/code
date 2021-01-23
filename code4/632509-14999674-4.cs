    class Program
    {
        static void Main(string[] args)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("date");
            dataTable.Columns.Add("unit");
            dataTable.Columns.Add("message");
            dataTable.Rows.Add("27.10.1989", "200", "someText");
            dataTable.Rows.Add("27.10.1989", "300", "someText");
            dataTable.Rows.Add("27.10.1989", "400", "someText");
            dataTable.Rows.Add("27.10.1989", "100", "someText");
            dataTable.Rows.Add("27.10.1989", "300", "someText");
            dataTable.Rows.Add("27.10.1989", "700", "someText");
            List<Dto> dto = new List<Dto>();
            foreach (DataRow row in dataTable.AsEnumerable())
            {
                dto.Add(new Dto(){DateTime = DateTime.Parse(row[0].ToString()), Message = row[2].ToString(), Unit = Convert.ToInt32(row[1])});
            }
            var groupedList = dto.GroupBy(e => e.Unit)
                 .Select(
                     e =>
                     new GroupedDto()
                     {
                         DateTime = e.AsQueryable().First().DateTime,
                         Message = e.AsQueryable().First().Message,
                         Unit = e.AsQueryable().First().Unit,
                         Count = e.Count()
                     })
                 .ToList();
        }
    }
    public class GroupedDto : Dto
    {
        public Int32 Count { get; set; }
    }
    public class Dto
    {
        public DateTime DateTime { get; set; }
        public Int32 Unit { get; set; }
        public String Message { get; set; }
    }
