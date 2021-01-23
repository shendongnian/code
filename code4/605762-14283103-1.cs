        private void button2_Click(object sender, EventArgs e)
        {
            int countChar = textBox1.Text.Trim().Count();
            if (string.IsNullOrWhiteSpace(textBox1.Text)) //if (countChar == 0)
            {
                MessageBox.Show("empty");
                return;
            }
            if (countChar >= 20)
            {
                MessageBox.Show("You have entered " + countChar.ToString() + " letters, Too many letters");
                return;
            }
            MessageBox.Show("Success");
        }
