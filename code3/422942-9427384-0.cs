    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if(Request.QueryString["msg"] != null)
            {
                litMsg.Text = "<div id='msgTxt' style='display:none;background-color:red;'>" + Request.QueryString["msg"] + "</div>";
            }
        }
    }
