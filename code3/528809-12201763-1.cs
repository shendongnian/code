    Table tbl = new Table(); // Creating a new table
    TableHeaderRow header = new TableHeaderRow(); // Creating a header row
    tbl.Rows.Add(header); // Add the header row to table tbl        
        // Creating Dynamic TextBox Control
    TextBox t = new TextBox();
    t.ID = "myTextBox"; // assing an ID
        // Now add this in a table row
    TableRow rowNew = new TableRow(); // Creating a new table row
    rowNew.Cells[0].Controls.Add(t);         // add the textbox control at cell zero
                 // or you can add it as
    rowNew.Controls.Add(t);
     
