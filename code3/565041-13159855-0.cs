    protected void Ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl   = (DropDownList)  sender;
        RepeaterItem item  = (RepeaterItem)  ddl .NamingContainer;
        TextBox txt        = (TextBox) item.FindControl("TextBox4");
        txt.Text           = ddl.SelectedItem.Text;
    }
