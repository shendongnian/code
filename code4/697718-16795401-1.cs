    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) // this is to ensure that we're looking in an item that will contain controls, and not the header or footer
        {
            LoginView headLoginView = (LoginView)e.Item.FindControl("HeadLoginView") // FindControl is not recursive so we need a reference to a control we can look in to find the button
            LinkButton lbDelete = (LinkButton)headLoginView.FindControl("lbDelete");
            if (lbDelete != null) // check for a null otherwise this code will fail if the user is not logged in, because the controls inside the LoggedInTemplate will not be rendered
            {
                lbDelete.CommandArgument = DataBinder.Eval(e.Row.DataItem, "id").ToString(); // set the CommandArgument on the button using DataBinder.Eval
            }
        }
    }
