    protected void check1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string result = string.Empty;
    
        foreach (ListItem listitem in check1.Items)
        {
            if (listitem.Selected)
            {
               result += ("\u2022" + listitem.Text);
            }
        }
        Mail emailsystem = new Mail();
        emailsystem.GetEmail(comment.Text, StatusList.SelectedValue, result);
    }
