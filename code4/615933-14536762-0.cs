    public void HideChildTextBoxes(Control parent)
    {
        foreach(Control c in parent.Controls)
        {
            HideChildTextBoxes(c);
            if(c is TextBox) c.Visible = false;
        }
    }
