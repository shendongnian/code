    public DialogResult TopMostMessageBox(string message, string title, MessageBoxButtons button, MessageBoxIcon icon)
        {
            return DisplayMessageBox(message, title, button, icon);
        }
    public DialogResult DisplayMessageBox(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult result;
            using (var topmostForm = new Form {Size = new System.Drawing.Size(1, 1), StartPosition = FormStartPosition.Manual})
            {
                var rect = SystemInformation.VirtualScreen;
                topmostForm.Location = new System.Drawing.Point(rect.Bottom + 10, rect.Right + 10);
                topmostForm.Show();
                topmostForm.Focus();
                topmostForm.BringToFront();
                topmostForm.TopMost = true;
                result = MessageBox.Show(topmostForm, message, title, buttons, icon);
                topmostForm.Dispose();
            }
            //You might not need all these properties...
            return result;
        }
    //Usage
    TopMostMessageBox("Message","Title" MessageBoxButtons.YesNo, MessageBoxIcon.Question)
