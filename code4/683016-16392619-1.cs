     protected void Page_Load(object sender, EventArgs e)
        {
            
    if(!IsPostBack)
    {
    if (Session["Test"] != null) 
            {
                TextBox1.Text = Session["Test"].ToString();
            }
        }
    }
