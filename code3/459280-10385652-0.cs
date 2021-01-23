        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += Page_PreRender
            if (Session["userId"] == null)
                Response.Redirect("Login.aspx");
        }
        protected bool reloadNeeded {get; set;}
        protected void CreateObject(object sender, EventArgs e)
        {
            // SAVE THE NEW OBJECT
            reloadNeeded = true;
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if(reloadNeeded || !IsPostBack)
            // LOAD DATA FROM DB
        }
