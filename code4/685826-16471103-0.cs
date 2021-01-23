    protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["abc"] == null) {
                ...
                ...
                Session["abc"] = "something";
            }
        }
