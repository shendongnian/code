    TableHeaderRow header = new TableHeaderRow();
    // use this to add a new headerrow
    // Creating Dynamic TextBox Control
     TextBox t = new TextBox();
     t.ID = "myTextBox";
     
     // Now add this in any row
     TableRow rowNew = new TableRow();
     rowNew.Cells[0].Controls.Add(t); // adding control at Cell 0 of the row
           //  or you can add as
     rowNew.Controls.Add(t);
     
