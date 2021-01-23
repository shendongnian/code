    // Adds new overload for AppendText for rich textboxes
    public static class RichTextBoxExtensions
    {
            public static void AppendText(this RichTextBox txtbox, string text, Color color)
            {
                txtbox.SelectionStart = txtbox.TextLength;
                txtbox.SelectionLength = 0;
                txtbox.SelectionColor = color;
                txtbox.AppendText(text);
                txtbox.SelectionColor = txtbox.ForeColor;
            }
    };
