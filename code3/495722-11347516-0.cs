    Dictionary<string, string> items= new Dictionary<string, string>();
    items.Add("-1","-Select-");
    items.Add("Test1", "Test1");
    items.Add("Test2", "Test2");
    ddl.DataSource = items;
    ddl.DataValueField = "Key";
    ddl.DataTextField = "Value";
    ddl.DataBind();
