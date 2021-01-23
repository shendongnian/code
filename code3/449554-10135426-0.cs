    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("address", typeof(string));
            table.Rows.Add("name 1", "address 1");
            table.Rows.Add("name 1", "address 1");
            var query = table.AsEnumerable().Select(s => new Company { Name = (string)s["name"], Address = (string)s["address"] }).ToList();
        }
    }
    class Company
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
