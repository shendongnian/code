    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsUserControl)
        {
            CreateUserControlAllNews();        
        }
    }
    
    private void CreateUserControlAllNews()
    {
        Control featuredProduct = Page.LoadControl("path/usercontrol.ascx");
        featuredProduct.ID = "1234";
        plh1.Controls.Add(featuredProduct);
    }
