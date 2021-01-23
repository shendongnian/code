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
                      .GroupBy(row => row.Field<string>("URL_Link"))
                      .Select(grp => grp.First());
            foreach (var item in res)
            {
                string text = "";
                foreach (var clm in item.ItemArray)
                    text += string.Format("{0}\t", clm);
                Console.WriteLine(text);
            }
            Console.ReadLine();
        }
    }
