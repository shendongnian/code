    public static void ApplySkin(this Form form, Skin skin)
    {
        foreach (Control ctrl in form.Controls)
        {
            if (ctrl is TextBox)
            {
                TextBox textBox = (TextBox)ctrl;
                textBox.BackColor = skin.BackColor;
                textBox.ForeColor = skin.ForeColor;
                textBox.Font = skin.Font;
                ...
            }
            else if (ctrl is ComboBox)
            {
                ComboBox comboBox = (ComboBox)ctrl;
                comboBox.BackColor = skin.BackColor;
                comboBox.ForeColor = skin.ForeColor;
                comboBox.Font = skin.Font;
                ...
            }
            else if (ctrl is ...)
        }
    }
