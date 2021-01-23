    public void ClearTextBoxes(Control parent)
    {
        foreach(Control c in parent.Controls)
        {
            ClearTextBoxes(c);
            if(c is TextBox) c.Text = string.Empty;
            if(c is ComboBox) c.SelectedIndex = 0;
        }
    }
