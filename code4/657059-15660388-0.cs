    string selectedStyle = DropDownList1.SelectedItem.ToString();
    if (selectedStyle == "Dotted")
    {
        Panel1.BorderStyle = System.Web.UI.WebControls.BorderStyle.Dotted;
    }
    else if (selectedStyle == "Solid")
    {
        Panel1.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
    }
    // and so on ...
