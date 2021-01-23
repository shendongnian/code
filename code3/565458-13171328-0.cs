    protected virtual void RepeaterItemCreated(object sender, RepeaterItemEventArgs e)
    {
        DropDownList MyList = (DropDownList)e.Item.FindControl("ddl");
        MyList.SelectedIndexChanged += ddl_SelectedIndexChanged;
    }
    protected void Ddl_SelectedIndexChanged(object sender, EventArgs e)
     {
        txt.Text = ddl.SelectedItem.Text;
     }
