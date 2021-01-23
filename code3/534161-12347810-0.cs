    protected void Page_Load(object sender, EventArgs e)
    {
        if(! IsPostBack){
           string username = Session["username"].ToString();
           Label9.Text = username;
        }
    }
