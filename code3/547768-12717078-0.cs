    public string MyString{ get; set; }
    
    public void Page_Load(object sender, EventArgs e)
    {
        MyString = Request.QueryString["field1"];
    }
