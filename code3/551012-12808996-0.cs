    void changeLabel(Control c)
    {
        if (lbl.Name.StartsWith("label"))
        {
            lbl.Text = string.Empty;
        }
        foreach(Control _c in c.Controls)
            changeLabel(_c);
    }
