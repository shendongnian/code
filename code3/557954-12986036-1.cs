    protected void btnSelect_Click(object sender, EventArgs e)
            {
                Button b = (Button)sender;
                GridViewRow r = (GridViewRow)b.NamingContainer;
                ////// once you have the row in which the event occured, you can do every thing with it
                // like
                int id = Convert.ToInt32(gvProducts.DataKeys[r.RowIndex].Value);
                // or you can find control like
                HiddenField hf = (HiddenField)r.FindControl("myHiddenField")
            }
