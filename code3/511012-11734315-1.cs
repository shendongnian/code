    void AddControl(UserControl control, int id)
    {
        control.Tag = id;
        this.panel.Controls.Add(control);
    }
    UserControl GetControl(int id)
    {
        foreach (Control control in this.panel.Controls)
        {
            if (id == (int) control.Tag)
                return (UserControl) control;
        }
        return null;
    }
    // or using LINQ
    UserControl GetControl(int id)
    {
        return Controls.Cast<UserControl>()
                       .FirstOrDefault(control => id == (int) control.Tag);
    }
