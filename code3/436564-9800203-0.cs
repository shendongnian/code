    protected void Page_Load(object sender, EventArgs e)
    {
        String cart= String.Empty;
        if(!String.IsNullOrEmpty(Session["abc"].ToString()))
        {
            xyz= Session["abc"].ToString();
            // do Something();
        }
        else
        {
            // do Something();
        }
    }
