    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       if (e.CommandName == "btn")
       {
           DropDownList ddl = new DropDownList();
           ddl.ID = "DropDownList1";
           ddl.DataSource = new string[] { "one", "two" };
           ddl.DataBind();
           
           // your second dropdown would be created here in the same way
           pl.Controls.Add(ddl);
       }
    }
