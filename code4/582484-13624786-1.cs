    protected void Page_Load(object sender, EventArgs e)
    {                        
        if(!IsPostBack)
        {
           var item = new ListItem("k", "k");
           item.Selected = true;
           this.formatOfReport.Items.Add(item);
           item  = new ListItem("j", "j")
           this.formatOfReport.Items.Add(item);
        }
    }
    
