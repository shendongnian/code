    protected void Page_Load(object sender, EventArgs e)
    {
       if (Session["GameObj"] != null)
       {
           game = (Game) Session["GameObj"];
       }
        ...
