    protected void Page_Load(object sender, EventArgs e)  
    {  
        if(!Page.IsPostBack)  
        {       
            about.Attributes.Add("class", "current"); //initial setting here 
        }  
    }
    protected void about_click(object sender, EventArgs e)  
    {  
        about.Attributes.Add("class", "current");  
    }
