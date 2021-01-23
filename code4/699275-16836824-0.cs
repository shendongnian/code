    private String[] GetTextBoxStrings()
    {
        List<String> list = new List<String>();
        foreach (Control c in this.Controls)
        {
            if (c is TextBox)
                list.Add(((TextBox)c).Text);
        }
        return list.ToArray();
    }
