    List<String> List = new List<String>();
    if(Session["List"] != null)
    {
    List  = (List<String>)Session["List"];
    }
    if (ddlTransaction.SelectedIndex < 3)
    {
        List.Add(ddlTransaction.SelectedValue);
        Session["List"] = List;
    }
