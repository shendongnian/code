     private void cboViewType_KeyDown(object sender, KeyEventArgs e)
            {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control || e.KeyCode == Keys.F1 || ((Control.ModifierKeys & Keys.Alt) == Keys.Alt && e.KeyCode == Keys.C))
                {
                    // do whatever you want to do here...
                    MessageBox.Show("key overridden");
                    e.SuppressKeyPress = true;
                }
                //e.Handled = true;   // will not work for overriding the shortcut etc.
            }
