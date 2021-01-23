    class Program
    {
        static void Main(string[] args)
        {
            DataTable tbl = GetTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(tbl);
            //file path to write xml file
            ds.WriteXml("test.xml");
    
            DataSet ds2 = new DataSet();
            //file path to read xml file
            ds2.ReadXml("test.xml");
        }
        static DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
    
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            return table;
        }
    }
