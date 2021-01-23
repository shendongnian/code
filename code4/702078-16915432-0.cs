    List<LiteralControl> list = new List<LiteralControl>();
    protected void Page_Init(object sender, EventArgs e)
    {
        generateTable(); // When pass just here, it works well
    }
    private void generateTable()
    {
        Table tbl = new Table();
        // Here I create my table with controls
        int rows = 3;
        int cols = 2;
        for (int j = 0; j < rows; j++)
        {
            TableRow r = new TableRow();
            for (int i = 0; i < cols; i++)
            {
                TableCell c = new TableCell();
                LiteralControl l = new LiteralControl("row " + j.ToString() + ", cell " + i.ToString());
                // save a reference to the control for editing
                list.Add(l);
                c.Controls.Add(l);
                r.Cells.Add(c);
            }
            tbl.Rows.Add(r);
        }
        tableContainer.Controls.Clear(); // tableContainer is a Panel fixed in aspx page
        tableContainer.Controls.Add(tbl);
    }
    protected void txt_TextChanged(object sender, EventArgs e)
    {
        // edit controls here
        foreach (LiteralControl ctrl in list)
        {
            ctrl.Text = "TextChanged";
        }
    }
