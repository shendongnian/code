    DataTable duplicates = dataTable;
    duplicates.Rows.Clear(); /* Produces an empty duplicate of the 
    dataTable table to put the duplicates in */
    foreach (DataRow row in dataTable.Rows)
    {
         if (!duplicates.Rows.Contains(row))
         {    
             temp = row[0].ToString();
             foreach (DataRow rows in dataTable.Rows)
             {
                 if (temp == rows[0].ToString()&&!duplicates.Rows.Contains(rows)) //need unique key
                 {
                     tempdatatable.Rows.Add(row[0],row[1]);
                     
                 }
                 tempdatatable.DefaultView.Sort = "gscitations DESC";
                 dataGridView1.DataSource = tempdatatable;
             }
        }
    }
    foreach (DataRow row in duplicates.Rows)
    {
        dataTable.Rows.Remove(row);
    }
        
