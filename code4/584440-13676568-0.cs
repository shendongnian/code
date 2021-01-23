    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MyTestDiv.InnerText = Request.QueryString["DivMSG"];
        }
    }
