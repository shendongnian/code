     protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Test"] != null && Session["Test"].ToString().Length > 0)
            {
                TextBox1.Text = Session["Test"].ToString();
            }
        }
        Session["Test"] = string.Empty;
    }
    protected void Button1_Click(object sender, EventArgs e)
     {
        Session["Test"] = TextBox1.Text;
      }
