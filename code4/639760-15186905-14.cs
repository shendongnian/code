    private void AddTextChangedHandler(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.GetType() == typeof(TextBox)) {
                c.TextChanged += new EventHandler(C_TextChanged);
            } else {
                AddTextChangedHandler(c);
            }
        }
    }
