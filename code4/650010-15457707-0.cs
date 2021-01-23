    var rowsToDelete = new List<DataRow>();
    foreach (DataRow row in dataTable.Rows)
         {
             temp = row[0].ToString();
             foreach (DataRow rows in dataTable.Rows)
             {
                 if (temp == rows[0].ToString())
                 {
                     tempdatatable.Rows.Add(row[0],row[1]);
                     rowsToDelete.Add(rows);
                 }
                 tempdatatable.DefaultView.Sort = "gscitations DESC";
                 dataGridView1.DataSource = tempdatatable;
             }
         }
    rowsToDelete.ForEach( x => dataTable.Rows.Remove(x) );
