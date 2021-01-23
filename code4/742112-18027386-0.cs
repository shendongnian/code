    protected string LogoutUrl { 
        get { 
            return "~/logout/" + HttpContext.Current.Session["UserName"].ToString(); 
        }
    }
    protected void Page_Load(object sender, EventArgs e) {
        if(!IsPostBack) { DataBind(); }
    }
