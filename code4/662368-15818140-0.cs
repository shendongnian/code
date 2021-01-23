    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[10].Text == "Order has been dispatched.")
           e.Row.Cells[10].BackColor = Color.LawnGreen;
        if (e.Row.Cells[10].Text == "Order is being processed.")
            e.Row.Cells[10].BackColor = Color.Red;
    }
