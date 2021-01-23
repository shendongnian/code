        private void button10_Click_1(object sender, EventArgs e)
        {
            double box23;
            if (double.TryParse(textBox23.Text, out box23))
            {
                double L1 = double.Parse(textBox13.Text);
                double L2 = double.Parse(textBox16.Text);
                double wynik = L1 - L2;
                textBox23.Text = wynik.ToString();
                string str = textBox23.Text;
                string retString = str.Substring(0, 1);
                textBox21.Text = retString;
                if (box23 > 9)
                {
                    str = textBox23.Text;
                    retString = str.Substring(1, 1);
                    textBox22.Text = retString;
                }
            }
        }
