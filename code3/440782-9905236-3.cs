    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
       {
        String url = Request.ServerVariables["HTTP_REFERER"];
        if(!String.IsNullOrEmpty(url))
        {
            if (!url.ToUpper().Contains("CP.ASPX"))
            {
                Response.Redirect("http://a.sml.com.pk");
            }
            else if (!url.ToUpper().Contains("MILKSALE.ASPX") && !url.ToUpper().Contains("CP.ASPX"))
            {
                Response.Redirect("http://172.17.0.221:85/MilkSale.aspx");
            }
        }
       }        
    } 
