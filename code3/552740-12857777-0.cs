    private void txtBoxTargetDir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                var clipboard = Clipboard.GetText();
                if (Directory.Exists(clipboard))
                {
                    txtBoxTargetDir.Clear();
                    txtBoxTargetDir.Text = clipboard;
                    btnCreateRelease.Enabled = true;
                    txtBoxTargetDir.ReadOnly = true;
                }
                else
                {
                    txtBoxTargetDir.Clear();
                    txtBoxTargetDir.Text = "It's not a valid directory. Please provide a valid directory.";
                }
            }
        }
