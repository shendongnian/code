    void SetControl(ContextMenu menu, Control control)
    {
        if (control is TextBox)
            control.ContextMenu = menu;
        else
        {
            foreach (Control c in control.Controls)
                SetControl(menu, c);
        }
    }
