    private string cnn1;
    
    public MyClass()
    {
        if (ConfigurationManager.ConnectionStrings["connection_string_1"] != null)
        cnn1 = ConfigurationManager.ConnectionStrings["connection_string_1"].ConnectionString;
    }
