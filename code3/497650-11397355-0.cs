        using (DataTable dt = new DataTable())
        {
            dt.Columns.Add("EntryDE", typeof(string));
            dt.Columns.Add("Descr", typeof(string));
            dt.Columns.Add("Id", typeof(int));
            for (int i = 0; i < 10; i++) 
            {
                DataRow dr = dt.NewRow();
                dr["EntryDE"] = "abc";
                dr["Descr"] = "xyz";
                dr["Id"] = 1;
                dt.Rows.Add(dr);
            }
        }
