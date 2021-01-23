    protected void Page_Load(object sender, EventArgs e)     
    {
             if(!IsPostBack)
            {
                ClickCount = 0; 
            }
    }
    
    protected void lnkClickButton_Click(object sender, EventArgs e)
    {
                  int val = ClickCount ;
                  ClickCount  = val + 1; 
    }
