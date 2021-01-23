    protected void textBox_TextChanged(Object sender, EventArgs e)
    {
        TextBox txt = (TextBox) sender;
        GridViewRow gvRow = (GridViewRow) txt.NamingContainer;
        GridView gv = (GridView) gvRow.NamingContainer;
        // if you need the index of the column of the TextBox (as commented below)
         int colIndex = Enumerable.Range(0, gvRow.Cells.Count)
                       .First(i => gvRow.Cells[i] == txt.Parent);
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
