    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack){
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = true;
            Panel4.Visible = false;
        }
    }
