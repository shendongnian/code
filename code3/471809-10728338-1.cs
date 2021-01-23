    static void RecurseClearAllTextBoxes(Control parent)
    {
        foreach (Control control in parent.Controls)
        {
            if (control is TextBox || control is RichTextBox)
                control.Text = String.Empty;
            else
                RecurseClearAllTextBoxes(control);
        }
    
        if (parent is TabControl)
        {
            foreach (TabPage tabPage in ((TabControl)parent).TabPages)
                RecurseClearAllTextBoxes(tabPage);
        }
    }
