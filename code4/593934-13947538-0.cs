            double value1, value2, value3, value4;
            try
            {
                value1 = Double.Parse(textBox1.Text);
            }
            catch (Exception)
            {
                value1 = 0;
            }
            try
            {
                value2 = Double.Parse(textBox2.Text);
            }
            catch (Exception)
            {
                value2 = 0;
            }
            [...]
            double total = value1 + value2 + value3 + value4;
            textBox5.Text = total.ToString();
