     class Program
    {
        static void Main(string[] args)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.AddRange(new DataColumn[]
                {
                   new DataColumn("Name",typeof(System.String)),
                   new DataColumn("Date",typeof(System.DateTime))
                });
            datatable.Rows.Add(new object[] { "Sam", DateTime.Now });
            datatable.Rows.Add(new object[] { null, DateTime.Now });
            IEnumerable<Results> subResult = from query in datatable.AsEnumerable()
                                             select new Results
                                                 {
                                                     Name = query.Field<string>("Name") ?? "0" ,
                                                     Date = query.Field<DateTime?>("Date")
                                                 };
        }
    }
    class Results
    {
        public string Name { get; set; }
        public DateTime? Date { get; set; }
    }
