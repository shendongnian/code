    void DoReadOnly(Control control)
    {
        foreach (Control c in control.Controls)
        {
            if (c.Controls != null && c.Controls.Count > 0)
            {
                DoReadOnly(c);
            }
            else if (c is TextBox)
            {
                (c as TextBox).ReadOnly = true;
            }
        }
    }
