     if (textBox.Text!="")
            {
                string txt = textBox.Text;
                if (e.KeyChar.ToString().Any(Char.IsNumber) || e.KeyChar == '.')
                {
                    textBox.Text = rate;
                }
                else
                {
                    MessageBox.Show("Number Only", "Warning");
                    textBox.Text = "";
                }
            }
