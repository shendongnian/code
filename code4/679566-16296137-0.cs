    class Program
    {
        static void Main(string[] args)
        {
            var dataset1 = CreateDataSet();
            var regex = new Regex(@"ab[1-3]{1}\d");
            //create dataset
            var oDS = new DataSet();
            var oTable = oDS.Tables.Add();
            oTable.Columns.Add("Foo1", typeof(int));
            oTable.Columns.Add("Name", typeof(string));
            oTable.Columns.Add("Foo2", typeof(int));
            
            var dataset2 = dataset1.Tables[0].AsEnumerable().Where(x => regex.IsMatch(x["Name"].ToString())).CopyToDataTable();
            foreach (DataRow row in dataset2.Rows)
            {
                Console.WriteLine(row["Name"]);
            }
            Console.ReadLine();
        }
        private static DataSet CreateDataSet()
        {
            //create dataset
            var oDS = new DataSet();
            // create datatable
            var oTable = oDS.Tables.Add();
            //Add coloms
            oTable.Columns.Add("Foo1", typeof(int));
            oTable.Columns.Add("Name", typeof(string));
            oTable.Columns.Add("Foo2", typeof(int));
            //Add rows
            oTable.Rows.Add(1, "ab01");
            oTable.Rows.Add(2, "ab10");
            oTable.Rows.Add(3, "ab11");
            oTable.Rows.Add(4, "ab21");
            oTable.Rows.Add(5, "ab22");
            oTable.Rows.Add(6, "ab31");
            oTable.Rows.Add(7, "ab32");
            oTable.Rows.Add(8, "ab41");
            return oDS;
        }   
    }
