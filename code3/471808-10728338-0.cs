    static void RecurseClearAllTextBoxes(Control parent)
    {
        foreach (Control control in parent.Controls)
        {
            if (control is TextBox || control is RichTextBox)
                control.Text = String.Empty;
            else
                RecurseClearAllTextBoxes(control);
        }
    }
