    protected void Page_Load(object sender, EventArgs e) {
        if (Request.QueryString["IsMeal"] != null) {
            if (Boolean.Parse(Request.QueryString["IsMeal"])) {
                txtDescription.Visible = true;
            }
            else {
                txtDescription.Visible = false;
            }
        }
    }
