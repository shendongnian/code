    protected void RapidOrderEntry_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int cellIndex = 0;
                foreach (TableCell c in e.Row.Cells)
                {
                    TextBox l = new TextBox();
                    l.ID = string.Format("QuantityTextBox_{0}_{1}", e.Row.RowIndex, cellIndex);
                    l.Text = "0";
                    l.CssClass = "QuantityTextBox";
                    Label b = new Label();
                    b.ID = string.Format("PartNumberLabel_{0}_{1}", e.Row.RowIndex, cellIndex);
                    b.CssClass = "labelNone";
                    Label x = new Label();
                    x.Text = "&nbsp;";
                    x.CssClass = "null";
                    b.Text = c.Text;
                    if (c.Text == "&nbsp;")
                    {
                        c.Controls.Add(x);
                    }
                    else
                    {
                        c.Controls.Add(l);
                        c.Controls.Add(b);
                    }
                    cellIndex++;
                }
            }
        }
