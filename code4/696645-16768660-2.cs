    protected void Page_Load(object sender, EventArgs e)
    {
    	UC1.DDLData = new []
    		{
    			new ListItem("1st Item", "0"),
    			new ListItem("2nd Item", "1"),
    			new ListItem("3rd Item", "2"),
    		};
    	UC1.DataBind();
    }
