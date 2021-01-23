            Regex reg = new Regex("^[0-9]+\\.[0-9]{1,2}$");
            Regex reg1 = new Regex("^[0-9]+\\.[0-9]{2}$");
            if (reg.IsMatch(textBox1.Text.ToString()))
            {
                if (!reg1.IsMatch(textBox1.Text))
                {
                    textBox1.Text += 0;
                }
            } 
