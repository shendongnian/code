    void TextBoxesName(Control parent)
    {
        foreach (Control child in parent.Controls)
        {
            TextBox textBox = child as TextBox;
            if (textBox == null)
                ClearTextBoxes(child);
            else
                MessageBox.Show(textbox.Name);
        }
    }
        TextBoxesName(this);
