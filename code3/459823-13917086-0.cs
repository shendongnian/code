     protected void grd_Pre(object sender, EventArgs e)
    {
        GridViewRow gv = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        TableCell tc = new TableCell();
        tc.ColumnSpan = 3;
        tc.Text = "GridView Header";
        tc.Attributes.Add("style", "text-align:center");
        gv.Cells.Add(tc);
        this.GridView1.Controls[0].Controls.AddAt(0, gv);
    }
