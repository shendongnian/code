    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Test"] != null)
            {
                TextBox1.Text = Session["Test"].ToString();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["Test"] = TextBox1.Text;
    }
