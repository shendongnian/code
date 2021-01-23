    protected void textBox_TextChanged(Object sender, EventArgs e)
    {
        TextBox txt = (TextBox) sender;
        GridViewRow gvRow = (GridViewRow) txt.NamingContainer;
        GridView gv = (GridView) gvRow.NamingContainer;
        // if you need the index of the column of the TextBox
        // as commented below you're using .NET 2.0
        int colIndex;
        for (int i = 0; i < gvRow.Cells.Count; i++)
        {
            if (gvRow.Cells[i] == txt.Parent)
            {
                colIndex = i;
                break;
            }
        }
        double total = 0;
        foreach (GridViewRow row in gv.Rows)
        {
            TextBox tb = (TextBox)row.FindControl(txt.ID);
            double d;
            if (double.TryParse(tb.Text, out d))
                total += d;
        }
        var tbFooter = (TextBox) gv.FooterRow.FindControl(txt.ID);
        tbFooter.Text = total.ToString();
    }
