     protected void Page_Load(object sender, EventArgs e)
     {
         if( !IsPostBack )
         {
            ViewState["RefUrl"] = Request.UrlReferrer.ToString();
         }
      }
