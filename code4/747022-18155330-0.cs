    using(PsqlConnection cn = new PsqlConnection("your connection string here"))
    {
         cn.Open(); 
         string[] selection = new string[] { table }; 
         DataTable tbl = cn.GetSchema("Tables", selection); 
         foreach (DataRow row in tbl.Rows)
         { 
             Console.WriteLine(row["TABLE_NAME"] + " " + row["COLUMN_NAME"]); 
         } 
    }
