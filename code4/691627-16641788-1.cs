    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.PreviousPage != null && PreviousPage.IsCrossPagePostBack == true)
        {
            TextBox1.Text = PreviousPage.ChangePassword.Text;
        }
    }
