    protected void Page_Load(object sender, System.EventArgs e)
    {
    	MyButton.OnClientClick = "alert('MyButton clicked!');";
    }
    
    protected void MyButton_Click(object sender, System.EventArgs e)
    {
    	Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", "alert('MyButton clicked!');", true);
    }
