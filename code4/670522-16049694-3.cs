    private string testName = "MyName";
    public string ReturnName
    {
        private set { testName = value; }
        get { return testName; }
    }
    
    //
    string i = data.ReturnName;
