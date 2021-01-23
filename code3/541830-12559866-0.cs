    protected void Page_Load(object sender, EventArgs e) 
    {
        if(Request.QueryString["ProjectID"] != null)
        {
           strProjectID = Request.QueryString["ProjectID"].ToString();
        }
        if (JQGrid1.AjaxCallBackMode != AjaxCallBackMode.None)            
        {               
            // save the last grid state in session - to be used for exporting                
            Session["gridFilterPageState"] = JQGrid1.GetState();            
        }
    }
