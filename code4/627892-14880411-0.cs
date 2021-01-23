    public void ClearTextBoxes(Control parent)
    {
        foreach(Control c in parent.Controls)
        {
            ClearTextBoxes(c);
            if(c is TextBox) c.Clear();
        }
    }
