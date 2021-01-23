    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              if(!string.IsNullOrEmpty(Request.QueryString["id"]))
                 {
                    GetUserScraps(int.Parse(Request.QueryString["id"].ToString()));
                 }
            }
         }
