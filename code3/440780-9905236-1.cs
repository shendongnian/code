    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
       {
        String url = Request.ServerVariables["HTTP_REFERER"];
        if (url != "http://172.17.0.221:84/CP.aspx")
        {
            Response.Redirect("http://a.sml.com.pk");
        }
        else if (!String.IsNullOrEmpty(url) || url != "http://172.17.0.221:85/MilkSale.aspx")
        {
            Response.Redirect("http://172.17.0.221:85/MilkSale.aspx");
        }
       }        
    } 
