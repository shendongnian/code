        private void button1_Click(object sender, EventArgs e)
        {
            //Disable the groupBox with textBox1 in it
            groupBox1.Enabled = false;
            //Simulate the Click on textBox1
            textBox1_MouseClick(this, new MouseEventArgs(MouseButtons.Left, 1,0,0,0));
        }
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Test");
        }
