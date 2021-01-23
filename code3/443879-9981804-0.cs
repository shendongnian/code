    protected void Page_Load(object sender, EventArgs e)
    {
        MasterPageClassName MyMasterPage = (MasterPageClassName)Page.Master; 
        
        TextBox t = new TextBox();
        t.TextChanged += new EventHandler(MyMasterPage.usernameTextBox_TextChanged);
    }
