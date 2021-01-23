            DataTable dt = new DataTable();
            dt.Columns.Add("bool", typeof(Boolean));
            dt.Rows.Add(true);
            dt.Rows.Add(false);
            dt.Rows.Add(true);
            DataView dv = new DataView(dt);
            dv.RowFilter = "bool = 1";
            
            foreach (DataRowView drv in dv)
            {
                Console.WriteLine(drv[0].ToString());
            }
