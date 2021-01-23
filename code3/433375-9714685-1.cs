    protected void dlSample_ItemDataBound(object sender, DataListItemEventArgs e)
            {
                try
                {
                    if (e.Item.DataItem.ToString().Equals("1"))
                        ((Label)e.Item.FindControl("lbl")).Text = "One";
                }
                catch (Exception ex)
                {
    
                    throw;
                }
            }
