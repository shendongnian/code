    protected void Page_Load(object sender, EventArgs e)
    {
        Set_Control_State();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Session["admin"] = "true";
        Set_Control_State();
    }
    protected void Set_Control_State()
    {
        String admin = (String)(Session["admin"]) ?? "";
        if (!admin.Equals("true"))
        {
            Label2.Visible = false;
            TextBox2.Visible = false;
            Button2.Visible = false;
        }
    }
