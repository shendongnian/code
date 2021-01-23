    private void AddTextChangedHandler(Control parent)
    {
        foreach (Control C in parent.Controls)
        {
            if (C.GetType() == typeof(TextBox)) {
                C.TextChanged += new EventHandler(C_TextChanged);
            } else {
                AddTextChangedHandler(C);
            }
        }
    }
