    //protected void grdSettlement_InsertCommand(object source, GridItemEventArgs e)
    protected void grdSettlement_InsertCommand(object source, GridCommandEventArgs e)
    {
        GridEditableItem ge = e.Item as GridEditableItem;
        if (ge != null)
        {
            //Good way is change TextBox ID 
            TextBox tb = ge["No"].FindControl("No") as TextBox;
            if (tb != null)
            {
                tb.Text = "007";
            }
        }
    }
