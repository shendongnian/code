         private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                ChangeTextBoxtoWatermark();
        }
        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "username")
            {
                textBox1.Text = "";
                textBox1.Font = new Font(this.Font, FontStyle.Regular);
                textBox1.BackColor = Color.White;
            }
        }
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                ChangeTextBoxtoWatermark();
        }
        private void ChangeTextBoxtoWatermark()
        {
            textBox1.Font = new Font(this.Font, FontStyle.Italic);
            textBox1.BackColor = Color.LightYellow;
            textBox1.Text = "username";
        }
