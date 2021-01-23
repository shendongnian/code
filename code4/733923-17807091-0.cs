        private static void ExportToDB()
        {
             SqlConnection con = new SqlConnection(@"Data Source=SHAWHP\SQLEXPRESS;Initial Catalog=FOO;Persist Security Info=True;User ID=sa");
             string filepath = @"E:\Temp.csv";
            StreamReader sr = new StreamReader(filepath);
            string line = sr.ReadLine();
            string[] value = line.Split(',');
            DataTable dt = new DataTable();
            DataRow row;
            foreach (string dc in value)
            {
                dt.Columns.Add(new DataColumn(dc));
            }
             
            int i = 1000; // chunk size
            while ( !sr.EndOfStream )
            {
                i--
                value = sr.ReadLine().Split(',');
                if(value.Length == dt.Columns.Count)
                {
                    row = dt.NewRow();
                    row.ItemArray = value;
                    dt.Rows.Add(row);
                }
                if(i > 0)
                   continue;
                WriteChunk(dt);                 
                i = 1000;
            }
            WriteChunk(dt);
          
        }
    void WriteChunk(DataTable dt)
    {
        using(SqlBulkCopy bc = new SqlBulkCopy(con.ConnectionString, SqlBulkCopyOptions.TableLock))
        {
            bc.DestinationTableName = "tblparam_test";
            bc.BatchSize = dt.Rows.Count;
            using(con.Open())
            {
                bc.WriteToServer(dt);
            }
        }
        dt.Rows.Clear()
    }
