     protected void Page_Load(object sender, EventArgs e)
     {
            if (!IsPostBack)
            {
                
                if (Session["Username"] != null)
                    Logout.Visible = true;
                else
                     Logout.Visible = false;
            }
     }
