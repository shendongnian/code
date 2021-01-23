     protected void Page_Load(object sender, EventArgs e)     
   {
     if(!IsPostBack)
    {
         Session["clickcount"] = 0;
         Cache["clickscount"] = 0;
    }
