        private void textBox1_Leave(object sender, EventArgs e)
        {
            string s = (sender as TextBox).Text;
            int i = Convert.ToInt16(s);
            if (i > 100)
            {
                MessageBox.Show("Number greater than 100");
                (sender as TextBox).Focus();
            }
        }
