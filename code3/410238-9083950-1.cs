    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["admin"] = null;
        }
        Set_Control_State();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        String admin = (String)(Session["admin"]) ?? "";
        if (admin.Equals("true"))
        {
            Session["admin"] = null;
        }
        else
        {
            Session["admin"] = "true";
        }
        Set_Control_State();
    }
    protected void Set_Control_State()
    {
        String admin = (String)(Session["admin"]) ?? "";
        if (admin.Equals("true"))
        {
            btnLogin.Text = "Log Out";
            Label2.Visible = true;
            TextBox2.Visible = true;
            Button2.Visible = true;
        }
        else
        {
            btnLogin.Text = "Log In";
            Label2.Visible = false;
            TextBox2.Visible = false;
            Button2.Visible = false;
        }
    }
