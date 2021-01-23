    public void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }
    
        Label myLabel = e.Row.FindControl("lblTotalCollected") as Label;
        MyClass myDataItem = e.Row.DataItem as MyClass;
        if(...)
        {
            myLabel.Text = myDataItem.Balance;
        }
        else
        {
            myLabel.Text = myDataItem.AmountCollected;
        }
    }
