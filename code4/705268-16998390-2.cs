    foreach (DataListItem item in DataList4.Items)
    {
        Repeater RepeaterQ = ((Repeater)(item.FindControl("Repeater1")));
        //string categories = ((Label)(item.FindControl("categoryLabel"))).ToString();
        string categories = ((Label)(item.FindControl("categoryLabel"))).Text;
        string[] arr1 = categories.Split(',');
        RepeaterQ.DataSource = arr1;
        RepeaterQ.DataBind();
    }
