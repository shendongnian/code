    tabControl1.KeyDown+=new KeyEventHandler(tabControl1_KeyDown);
----------------------------------------------------------
    private void tabControl1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    e.Handled = true;
                }
            }
