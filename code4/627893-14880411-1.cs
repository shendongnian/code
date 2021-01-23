    public void ClearTextBoxes(Control parent)
    {
        foreach(Control c in parent.Controls)
        {
            ClearTextBoxes(c);
            if(c is TextBox) c.Clear();
            if(c is ComboBox) c.SelectedIndex = 0;
        }
    }
