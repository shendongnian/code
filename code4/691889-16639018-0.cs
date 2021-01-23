    protected void ButtonCliked(object sender, EventArgs e)
    {
        string buttonID = "";
        if (sender is Button)
        {
            buttonID = ((Button)sender).ClientID;
            string url = "RedirectUrl.aspx?buttonID=" + buttonID;
            Response.Redirect(url);
        }
    }
