    /adding first row
    TableRow row1 = new TableRow();
    
    //adding first cell
    TableCell cell1 = new TableCell();
    
    //adding label
    Label text1 = new Label();
    text1.Text = "Just test";
    
    cell1.Controls.Add(text1);
    row1.Controls.Add(cell1);
    table1.Controls.Add(row1);
