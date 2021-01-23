    protected void Page_Load(object sender, EventArgs e)
     {
        if( IsPostBack ) 
        {
            string senderControl = Request.Params["__EVENTTARGET"].ToString();
            //senderControl will contain the name of the button/control responsible for PostBack
        }
      }
