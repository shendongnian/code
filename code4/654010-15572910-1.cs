    public void dataGridView1_RowDataBound(Object sender, GridViewRowEventArgs e)  
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            Product currentProduct = e.Item.DataItem as Product;
            TimeSpan diffDate = DateTime.Now - currentProduct.ExpireDate;
            if (dateDiff < TimeSpan.FromDays(0))
            {
                row.DefaultCellStyle.BackColor = Color.Yellow;
            }
            else if (dateDiff < TimeSpan.FromDays(7))
            {
                row.DefaultCellStyle.BackColor = Color.Red;
            }
        }  
    }
