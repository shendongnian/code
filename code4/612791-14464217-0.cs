            if (Regex.IsMatch(textBox1.Text, @"^(?!\s*$).+")) //Check Not Empty String 
            {
                if (Regex.IsMatch(textBox1.Text, @"^\d{10}$")) // Check ten digits - Not allowed Alphanumeric
                {
                    MessageBox.Show("find Ten digits");
                }
                else
                {
                        MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("Empty String Found");
            }
