    void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button btnTest = (Button)e.Row.FindControl("btnTest");
            btnTest.Text = "I'm in a Template Field";
        }
    }
