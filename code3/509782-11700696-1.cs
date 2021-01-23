        if (textBox1.Text != string.Empty && !Regex.IsMatch(textBox1.Text, @"^[0-9]+$"))
        {
            MessageBox.Show("Please only enter numbers");
            textBox1.Clear();
        }
        else
        {
            // your statements
        }
