       private void cellClicked(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right) // right click
            {
                if (Control.ModifierKeys == Keys.Control)
                   System.Diagnostics.Debug.Print("CTRL + Right click!");
                else
                   System.Diagnostics.Debug.Print("Right click!");
            }
            if (e.Button == MouseButtons.Left) // left click
            {
                if (Control.ModifierKeys == Keys.Control)
                    System.Diagnostics.Debug.Print("CTRL + Left click!");
                else
                    System.Diagnostics.Debug.Print("Left click!");
            }
        }
