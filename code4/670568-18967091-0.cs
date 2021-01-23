    protected void btnSend_Click(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            sendEmail(); //this gets automatically called when parent page is loaded. 
        }
    }
