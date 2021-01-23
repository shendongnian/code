    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       if (e.CommandName == "btn")
       {
           DropDownList ddl = new DropDownList();
           ddl.ID = "DropDownList1";
           ddl.DataSource = new string[] { "one", "two" };
           ddl.DataBind();
           ddl.AutoPostBack = true;
           ddl.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
           
           // your second dropdown would be created here in the same way
           pl.Controls.Add(ddl);
       }
    }
