    public void Dedupe(Object o, EventArgs e)
    {
        String output = "start ";
        IEnumerable<GridViewRow> rows = from r in GV0.Rows
                                        where r.RowType == DataControlRowType.DataRow
                                        select r;
        foreach (GridViewRow row in rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
            if (cb.Checked)
            {
                output += row.Cells[1];
            }
        }
        Label1.Text = output;
    }
