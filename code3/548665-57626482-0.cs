        private void scintilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                // Saving ...
                e.SuppressKeyPress = true;
            }
        }
