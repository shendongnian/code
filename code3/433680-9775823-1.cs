    public new string ConnectionString {
        get { 
            return base.ConnectionString; 
        }
        //you could set your own connection string here
        set { 
            base.ConnectionString = ConfigurationManager.ConnectionStrings ["Sql"].
                ConnectionString; 
        }
    }
