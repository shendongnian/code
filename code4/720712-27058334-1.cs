    protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
            {
                try
                {
    
                        DataSet dset3 = new DataSet();
                        GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
                        TextBox qty = (TextBox)currentRow.FindControl("txtqty");
                        TextBox qty1 = (TextBox)currentRow.FindControl("txtUnitPrice");
                        string a = qty.Text;
                        TextBox totalprice = (TextBox)currentRow.FindControl("txttotal");
                        totalprice.Text = (Double.Parse(qty1.Text) * Double.Parse(qty.Text)).ToString();
                    
                }
                catch (Exception ex)
                {
    
                }
    
            }
