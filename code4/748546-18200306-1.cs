        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                
                if (label1.BackColor == Color.Blue)
                {
                    label1.BackColor = Color.Red;
                    MessageBox.Show("The color is red.");
                }
                else
                {
                    label1.BackColor = Color.Blue;
                    MessageBox.Show("The color is blue.");
                }
            }
            else
            {
                MessageBox.Show("You need the check box checked first!");
            }
        }
