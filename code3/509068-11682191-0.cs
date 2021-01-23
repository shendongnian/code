    var conditionals = new Dictionary<string, string>();
    
    foreach(Control c in Page.Controls)
    {
        if (c is TextBox)
        {
            if (!String.IsNullOrEmpty(c.Text))
                conditionals.Add(c.Id, c.Text);
        }
    }
