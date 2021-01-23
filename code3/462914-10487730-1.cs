    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                HyperLink myLink = new HyperLink();
                myLink.NavigateUrl = "somewhere.aspx";
                if (cell.Controls.Count > 0)
                {
                    while (cell.Controls.Count > 0)
                    {
                        myLink.Controls.Add(cell.Controls[0]);
                    }
                }
                else
                {
                    myLink.Text = cell.Text;
                }
                cell.Controls.Add(myLink);
            }
        }
    }
