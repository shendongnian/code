    if (e.CommandName == "Filter")
         {
            DataTable dt = new DataTable();
            td.Columns.Add("Column1");
            td.Columns.Add("Column2");
            //etc.
            //add same columns as you have in RadGrid2
            foreach (GridDataItem item in RadGrid2.Items)
            {
                
                for (int i = 0; i < RadGrid2.Items.Count; i++ )
                {
                    dt.Rows.Add(item);
                }
            }
