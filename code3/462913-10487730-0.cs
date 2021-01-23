    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach (TableCell c in e.Row.Cells)
            {
                HyperLink l = new HyperLink();
                l.NavigateUrl = "somewhere.aspx";
                if (c.Controls.Count > 0)
                {
                    while (c.Controls.Count > 0)
                    {
                        l.Controls.Add(c.Controls[0]);
                    }
                }
                else
                {
                    l.Text = c.Text;
                }
                c.Controls.Add(l);
            }
        }
    }
