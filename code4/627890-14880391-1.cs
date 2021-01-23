    public void ClearTextBoxes(Control control)
    {
        foreach (Control c in control.Controls)
        {
            if (c is TextBox)
            {
                ((TextBox) c).Clear();
            }
            else if (c is ComboBox)
            {
                ((ComboBox)c).SelectedIndex = 0;
            }
            else if (c is NumericUpDown)
            {
                ((NumericUpDown)c).Value = 0;
            }
            if (c.HasChildren)
            {
                ClearTextBoxes(c);
            }
        }
    }
