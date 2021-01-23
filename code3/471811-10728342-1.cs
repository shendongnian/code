    foreach (TabPage t in tabControl1.TabPages)
    {
        foreach (Control c in t.Controls)
        { 
            if (c is TextBox || c is RichTextBox)
            {
                c.Text = "";
            }
        }
    }
