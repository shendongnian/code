        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                if (textBox1.Text.Contains("-") && (textBox1.Text.Substring(0, 1) != "-" || textBox1.Text.Split('-').Length > 2))
                {
                    bool headingDash = false;
                    if (textBox1.Text.Substring(0, 1) == "-")
                    {
                        headingDash = true;
                    }
                    textBox1.Text = textBox1.Text.Replace("-", "");
                    if (headingDash)
                    {
                        textBox1.Text = "-" + textBox1.Text;
                    }
                }
            }
        }
