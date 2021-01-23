        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button== MouseButtons.Right)
            {
                int nowIndex = e.Y / listBox1.ItemHeight;
                if (nowIndex < listBox1.Items.Count)
                {
                    listBox1.SelectedIndex = e.Y / listBox1.ItemHeight;
                }
                else
                {
                    //Out of rang
                }
            }
        }
