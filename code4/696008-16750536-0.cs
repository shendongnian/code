                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[]{
                    new DataColumn("Column1"),
                    new DataColumn("Column2"),
                    new DataColumn("Column3")});
    
                dt.PrimaryKey = new DataColumn[] { dt.Columns[0], dt.Columns[1], dt.Columns[2] };
    
                // Load your data from XML file.
    
                try
                {
                    //dt.Rows.Add(new DataRow)
                }
                catch (Exception ex)
                {
    
                }
    // BulkCopy Code here.
