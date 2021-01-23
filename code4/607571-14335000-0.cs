    int iterationTimes = 10;
    
    for (int i = 1; i <= iterationTimes ; i++)
    {
        TableRow tr = new TableRow();
        TableCell tc = new TableCell();
        Label lbl = new Label();
        lbl.Text = link;
        tc.Controls.Add(lbl);
        tr.Cells.Add(tc);
        tblMain.Rows.Add(tr);
    }
