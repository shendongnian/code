    create a RowCreated Event on your grid... easy as that (this will swap the row to end,, no need to turn off auto generate... 100% worked for me)
    
     protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
            {
                GridViewRow row = e.Row;
                // Intitialize TableCell list
                List<TableCell> columns = new List<TableCell>();
                foreach (DataControlField column in GridView1.Columns)
                {
                    //Get the first Cell /Column
                    TableCell cell = row.Cells[0];
                    // Then Remove it after
                    row.Cells.Remove(cell);
                    //And Add it to the List Collections
                    columns.Add(cell);
                }
                // Add cells
                row.Cells.AddRange(columns.ToArray());
            }
