     //Creat the Table and Add it to the Page
                Table table = new Table();
                table.ID = "Table1";
                Page.Form.Controls.Add(table);
                // Now iterate through the table and add your controls 
                for (int i = 0; i < rowsCount; i++)
                {
                    TableRow row = new TableRow();
                    for (int j = 0; j < colsCount; j++)
                    {
                        TableCell cell = new TableCell();
                        TextBox tb = new TextBox();
    
                        // Set a unique ID for each TextBox added
                        tb.ID = "TextBoxRow_" + i + "Col_" + j;
    
                        // Add the control to the TableCell
                        cell.Controls.Add(tb);
                        // Add the TableCell to the TableRow
                        row.Cells.Add(cell);
                    }
                    // Add the TableRow to the Table
                    table.Rows.Add(row);
                }
