    public object DataSource
    {
        set{
            ddl.DataSource = value; 
            ddl.Databind();
            ddl.Items.Insert(0, new ListItem("---", "0"));
        }
    }
