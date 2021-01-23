    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
    if (DropDownList1.SelectedItem.Value.Length > 0)
    {
                    Response.Redirect("Page2.aspx?SelectedValue=" + DropDownList1.SelectedValue);
    }
    }
