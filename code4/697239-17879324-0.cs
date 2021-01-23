     protected void Page_Load(object sender, EventArgs e)
        {
            // Find the name on the previous page
            TextBox txt = (TextBox)Page.PreviousPage.FindControl("txtNameText");
    
            if (txt != null)
                txtName.Text = Server.HtmlEncode(txt.Text);
            else
                txtName.Text = "[Name Not available]";
        }
