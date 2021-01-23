    bool IsChecked(Control parent)
    {
        if (parent.Controls.OfType<RadioButton>().Any(rb => rb.Checked)) return true;
        
        foreach (Control c in parent.Controls)
            if (IsChecked(c)) return true;
        return false;
    }
    bool checked = IsChecked(_form);
