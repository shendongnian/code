    protected void lb_Command(object sender, CommandEventArgs e)
    {
        Label1.Text = e.CommandName; // will display the which Linkbutton clicked
        Label1.Text = "aaaa";
        //  Response.Redirect(“LnkBtn.aspx?val=” + Label1.Text); // you can also use as QueryString to send values to another page
    }
