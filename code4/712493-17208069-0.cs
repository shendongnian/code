        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && e.Modifiers == Keys.Control)
            {
                if (mainTabControl.SelectedIndex >= mainTabControl.TabCount - 1)
                    mainTabControl.SelectedIndex = 0;
                else
                    mainTabControl.SelectedIndex++;
            }
        }
