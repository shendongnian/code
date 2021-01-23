            conn.Open();
            var tableschema = conn.GetSchema("Tables");
            var firstsheet = tableschema.Rows[0]["TABLE_NAME"].ToString();
            string name_query = "SELECT F3 FROM [" + firstsheet + "]";
            OleDbDataAdapter da = new OleDbDataAdapter(name_query, conn);
            da.Fill(table);
            conn.Close();
            j = table.Rows.Count;
            var stringlist = table.Rows.Cast<DataRow>().Select(dr => dr[0].ToString()).ToList();
