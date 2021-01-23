    protected void Page_Load(object sender, EventArgs e)
    {
    if (!Page.IsPostBack)
        {            
            Session["Test"] = "";           
        }
        if (Session["Test"] != null)
        {    
            Session["Test"] = ASPxTextBox1.Text;            
        }
    }
   
    protected void ASPxButton1_Click(object sender, EventArgs e)
    {
        ASPxTextBox1.Text = Session["Test"].ToString();
    }
