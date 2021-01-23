    //page1.aspx:
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
         string greetingString = "Hello";
         Session["MyValue"] = greetingString;
         Response.Redirect("page2.aspx");
    }
    
    //page2.aspx:
    
    protected void Page_Load(object sender, EventArgs e)
    {
         Response.Write(Session["MyValue"].ToString());  //prints "Hello"
    }
