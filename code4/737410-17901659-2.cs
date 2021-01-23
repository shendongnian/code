    public void MakeReadOnlyTextBoxes(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.GetType() == typeof(TextBox))
            {
                ((TextBox)(c)).ReadOnly = true;
            }
            else if(c.Controls.Count > 0)
            {
                MakeReadOnlyTextBoxes(c);
            }
        }
    }
    public void ReadOnly()
    {
         ReadOnyTextBoxes(this);
    }
