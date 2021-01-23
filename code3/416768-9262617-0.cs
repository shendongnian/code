        for (int i = 0; i < 5; i++) {
           tr = new TableRow();
           //You can also do a loop for the cell
           TableCell c1 = new TableCell();
           TableCell c2 = new TableCell();
           TableCell c3 = new TableCell();
           c1.Text = "Cell One";
           c2.Text = "Cell Two";
           c3.Text = "Cell Three";
           tr.Cells.Add(c1);
           tr.Cells.Add(c2);
           tr.Cells.Add(c3);
           table1.Rows.Add(tr);
        }
        form1.Controls.Add(table1);
