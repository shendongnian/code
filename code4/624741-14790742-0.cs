        private int lastIndex = 0;
        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (listBox1.SelectedIndex == lastIndex)
            {
                if (e.KeyCode == Keys.Up)
                {
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
                if (e.KeyCode == Keys.Down)
                {
                    listBox1.SelectedIndex = 0;
                }                
            }
            lastIndex = listBox1.SelectedIndex;
        }
