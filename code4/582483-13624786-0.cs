    protected void Page_Load(object sender, EventArgs e)
    {                        
        if(!IsPostBack)
        {
           this.formatOfReport.Items.Add(new ListItem("k", "k", true));
           this.formatOfReport.Items.Add(new ListItem("j", "j"));
        }
    }
    
