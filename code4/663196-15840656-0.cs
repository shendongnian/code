    protected void Page_Load(object sender, EventArgs e)
    {
        bool visible = (lstExisting.Items.Count > 0); // assuming it's never null
        lblIsITYou.Visible = visible;
        btnYes.Visible = visible;
        btnNo.Visible = visible;
    }
