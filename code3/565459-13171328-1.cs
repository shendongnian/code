    protected virtual void RepeaterItemCreated(object sender, RepeaterItemEventArgs e)
    {
        DropDownList MyList = (DropDownList)e.Item.FindControl("ddl");
        MyList.SelectedIndexChanged += ddl_SelectedIndexChanged;
    }
    protected void Ddl_SelectedIndexChanged(object sender, EventArgs e)
     {
         RepeaterItem item  = (RepeaterItem)  Page.FindControl("repeatorid");
         TextBox txt        = (TextBox) item.FindControl("TextBox4");
         txt.Text           = ddl.SelectedItem.Text;     
     }
