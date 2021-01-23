     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               txtAmt.Visible = false;
    
             if(!txtAmt.visible) { txtamtValidator.Enabled=false};
    
            }
        }
