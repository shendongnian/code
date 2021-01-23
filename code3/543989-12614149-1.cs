    static string prevPage = String.Empty;
     
    protected void Page_Load(object sender, EventArgs e)
    {
         if( !IsPostBack )
         {
             prevPage = Request.UrlReferrer.ToString();
         }
     
     }
     
     protected void Button1_Click(object sender, EventArgs e)
     {
          Response.Redirect(prevPage);
     }
