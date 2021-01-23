            else
            {
                MessageBox.Show("Invalid Phone Number! \nFormat is (XXX) XXX-XXXX");
            }
            if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Field can't be left blank!");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("No Name for the Author!");
                return;
            }
