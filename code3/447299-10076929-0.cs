    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var updateCtrl = e.Row.FindControl("btnUpdate") as Button;
        if (updateCtrl != null)
        {
            if ((bool)DataBinder.Eval(e.Row.DataItem, "SomeBooleanValue"))
            {
                //if the conditions are metshow a confirm dialog 
                //when the button is clicked 
                updateCtrl.OnClientClick = "return confirm('Are you sure you want to update?');";
            }
        }
    }
