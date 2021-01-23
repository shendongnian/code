    public abstract class ControlUtilities
    {
        public static void AddTextBoxShortcuts(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is TextBox)
                {
                    TextBox txt = (TextBox)c;
                    txt.KeyDown += textBox_KeyDown;
                }
                else if (c.Controls != null && c.Controls.Count > 0)
                {
                    // recursively look for text boxes
                    AddTextBoxShortcuts(c.Controls);
                }
            }
        }
        private static void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (e.Control && e.KeyCode == Keys.A)
            {
                txt.SelectAll();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                txt.Copy();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                txt.Text = Clipboard.GetText();
                e.SuppressKeyPress = true;
            }
        }
    }
