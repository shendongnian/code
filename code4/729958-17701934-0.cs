    void GridView1_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        HtmlImage img = new HtmlImage() { Src = "add.png" };
        e.Row.Cells[1].Controls.Add(img);
    }
