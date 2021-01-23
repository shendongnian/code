        ListBox lb;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("."))
            {
                lb = new ListBox();
                lb.Location = textBox1.Location;
                this.Controls.Add(lb);
                lb.Items.Add("Item 1");
                lb.Items.Add("Item 2");
                lb.Items.Add("Item 3");
                lb.Show();
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                lb.Focus();
            }
        }
