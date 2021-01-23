    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        var gv = (GridView)sender;
        for (int i = 0; i < gv.Rows.Count; i++)
        {
            var oneRow = gv.Rows[i];
            String ProCol = oneRow.Cells[0].ToString();
            if (ProCol.Length != 0)
            {
                oneRow.Cells[0].ToolTip = ListBox1.Items[i].ToString().Trim();
            }
        } 
    }
