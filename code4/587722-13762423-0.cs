        DataTable dt = new DataTable();
        //Define columns to DataTable 
        dt.Columns.Add("Id");
        dt.Columns.Add("Name");
 
        //Adding rows to DataTable 
        DataRow row1 = dt.NewRow();
        row1["ID"] = 1;
        row1["Name"] = "Jack";
        dt.Rows.Add(row1);
        DataRow row2 = dt.NewRow();
        row2["ID"] = 2;
        row2["Name"] = "Fruit";
        dt.Rows.Add(row2);
        DataRow row3 = dt.NewRow();
        row3["ID"] = 3;
        row3["Name"] = "Ball";
        dt.Rows.Add(row3);
        dt.DefaultView.Sort = dt.Columns[1].ColumnName + " ASC";
        foreach (DataRowView drv in dt.DefaultView)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
                Console.WriteLine(drv[i]);
        }
