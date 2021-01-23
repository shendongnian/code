    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["clickcount"] == null){
           Session["clickcount"] = 0;
        }
    }
