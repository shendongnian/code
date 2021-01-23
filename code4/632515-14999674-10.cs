    class Program
    {
        static void Main(string[] args)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("date").DataType = typeof(DateTime);
            dataTable.Columns.Add("unit").DataType = typeof(Int32);
            dataTable.Columns.Add("message").DataType = typeof(String);
            dataTable.Rows.Add("27.5.1989", "200", "someText");
            dataTable.Rows.Add("27.6.1989", "300", "someText");
            dataTable.Rows.Add("27.7.1989", "400", "someText");
            dataTable.Rows.Add("27.8.1989", "100", "someText");
            dataTable.Rows.Add("27.9.1989", "300", "someText");
            dataTable.Rows.Add("27.10.1989", "700", "someText");
            var result = (from rows in dataTable.AsEnumerable()
                          select new Dto
                              {
                                  DateTime = rows.Field<DateTime>("date"),
                                  Unit = rows.Field<Int32>("unit"),
                                  Message = rows.Field<String>("message")
                              }).GroupBy(e => e.Unit)
                                .Select(
                                    e =>
                                    new GroupedDto()
                                        {
                                            DateMessage = GetDictionary(e),
                                            Unit = e.AsQueryable().First().Unit,
                                            Count = e.Count()
                                        }).ToList();
            int i = 5;
        }
        public static Dictionary<String, String> GetDictionary(IGrouping<int, Dto> input)
        {
            Dictionary<String, String> result =new Dictionary<string, string>();
            input.ToList().ForEach(e=>result.Add(e.DateTime.Date.ToString(), e.Message));
            return result;
        }
    }
    public class GroupedDto
    {
        public Int32 Unit { get; set; }
        public Dictionary<String, String> DateMessage { get; set; }
        public Int32 Count { get; set; }
    }
    public class Dto
    {
        public DateTime DateTime { get; set; }
        public Int32 Unit { get; set; }
        public String Message { get; set; }
    }
