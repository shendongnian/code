    class Program
    {
        static void Main(string[] args)
        {
            var dt = new DataTable();
            using (var reader = new ExcelDataReader(@"data.xlsx"))
            {                
                dt.Load(reader);
            }
    
            Console.WriteLine("done: " + dt.Rows.Count);
            Console.ReadKey();
       }
    }
