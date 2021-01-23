    protected void Button4_Click(object sender, EventArgs e)
    {
        // If you want to hide the message controls.
        Message.Visible = false;
    
        foreach (var message in Messages)
        {
            OutputMessages.Items.Add(new ListItem(Server.HtmlEncode(message)));
        }
    }
