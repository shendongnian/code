        class Program
        {
            static DataTable GetData()
            {
                DataTable table = new DataTable();
                table.Columns.Add("Visits", typeof(int));
                table.Columns.Add("URL_Link", typeof(string));
        
                table.Rows.Add(57, "yahoo.com");
                table.Rows.Add(130, "google.com");
                table.Rows.Add(92, "google.com");
                table.Rows.Add(25, "home.live.com");
                table.Rows.Add(30, "stackoverflow.com");
                table.Rows.Add(1, "stackoverflow.com");
                table.Rows.Add(7, "mysite.org");
                return table;
        }
    
        static void Main(string[] args)
        {
            var res = GetData()
                       .AsEnumerable()
                       .Select(d=>d.Field<string>("URL_Link"))
                       .Distinct();
    
            foreach (var item in res)
                Console.WriteLine(item.ToString());  
    
            Console.ReadLine();
        }
    }
