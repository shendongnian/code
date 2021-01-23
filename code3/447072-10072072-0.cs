        rdoTest.DataSource = new string[]
        {
            "Hello",
            "World",
        }; 
        rdoTest.DataBind();
        foreach (ListItem item in rdoTest.Items)
        {
            item.Attributes["title"] = item.Text;
        }
        
