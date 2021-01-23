     private DataTable parseCCSID65535(DataTable p_dt)
     {
         DataTable dt = new DataTable();
     
         // Build a new DataTable
         for (int i = 0; i < p_dt.Columns.Count; i++)
         {
             dt.Columns.Add(p_dt.Columns[i].Caption);
         }
     
         //loop through the rows
         for (int r = 0; r < p_dt.Rows.Count; r++)
         {
             //create a new row
             string[] row = new string[p_dt.Columns.Count];
     
             //loop through all columns
             for (int c = 0; c < p_dt.Columns.Count; c++)
             {
                 if (p_dt.Rows[r][c].GetType() == typeof(System.Byte[]))
                 {
                     // if this value is CCSID65535, change it ;-)
                     iDB2CharBitData cbd = new iDB2CharBitData((Byte[])p_dt.Rows[r][c]);
                     row[c] = cbd.ToString(65535);
                 }
                 else
                 {
                     // else: go on.
                     row[c] = p_dt.Rows[r][c].ToString();
                 }
             }
             // passing to the new DataTable.
             dt.Rows.Add(row);
         }
         return dt;
     }
