    using(PsqlConnection cn = new PsqlConnection("your connection string here"))
    {
         cn.Open(); 
         string[] selection = new string[] { null, null, table }; 
         DataTable tbl = cn.GetSchema("Columns", selection); 
         foreach (DataRow row in tbl.Rows)
         { 
             Console.WriteLine(row["COLUMN_NAME"].ToString() + " " + 
                               row["IS_NULLABLE"].ToString() + " " +
                               row["DATA_TYPE"].ToString() 
             );
         } 
    }
