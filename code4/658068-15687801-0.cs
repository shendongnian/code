    protected void timerAddRow_Tick(object sender, EventArgs e)
    {            
        TableRow r = new TableRow();
        TableCell c1 = new TableCell();
        Label test = new Label();
        test.ForeColor = System.Drawing.Color.Black;
        test.Font.Bold = true;
        test.Text = "Rank";
        c1.Controls.Add(test);
        r.Cells.Add(c1);
        tableTest.Rows.Add(r);
    }
