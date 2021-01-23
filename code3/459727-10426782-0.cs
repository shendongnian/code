    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //check if the webpage is loaded for the first time.
            {
                ViewState["PreviousPage"] = 
    		Request.UrlReferrer;//Saves the Previous page url in ViewState
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (ViewState["PreviousPage"] != null)	//Check if the ViewState 
    						//contains Previous page URL
            {
                Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to 
    		//Previous page by retrieving the PreviousPage Url from ViewState.
            }
        }
