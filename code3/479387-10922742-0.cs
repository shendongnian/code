    private List<string> Messages
    {
        get
        {
            var messages = Session["Messages"] as List<string>;
    
            if (messages == null)
            {
                messages = new List<string>();
                Session["Messages"] = messages;
            }
    
            return messages;
        }
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        Messages.Add(TextBox2.Text);
        TextBox2.Text = "";
    }
    
    protected void Button3_Click(object sender, EventArgs e)
    {
        Messages.Clear();
    }
    
    protected void Button4_Click(object sender, EventArgs e)
    {
        string output = "<ol>";
        foreach (string message in Messages)
        {
            output += "<li>";
            output += message;
            output += "</li>";
        }
        output += "</ol>";
        Message.InnerHtml = output;
    }
