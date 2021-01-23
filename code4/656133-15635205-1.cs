    protected void Page_Load(object sender, EventArgs e)
    {
     if (Request.Form["__VIEWSTATE"] != null)
        Session["Path"] = "//" + DropDownList1.SelectedValue + "//" + DropDownList2.SelectedValue + "//";
    }
    
