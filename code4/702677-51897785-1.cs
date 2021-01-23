    private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                MenuItem1.Visible = true;
            }
            if (e.KeyCode == Keys.F7)
            {
                MenuItem1.Visible = false;
            }
        }
 
