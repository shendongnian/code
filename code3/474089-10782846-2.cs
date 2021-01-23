    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack){
           Session["clickcount"] = 0;
           Cache["clickscount"] = 0;
        }
    }
