            string isNumber = @"^[1-9]{1}\.[1-9]{1}$";
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                TextBox text = (TextBox)sender;
    
                Match match;
    
                switch (text.Text.Length)
                {
                    case 1:
                        if (char.IsDigit(text.Text[0]))
                            break;
                        else
                            text.Text = "";
                        break;
                    case 2:
                        if (char.IsPunctuation(text.Text[1]))
                            break;
                        else
                        {
                            text.Text = text.Text.Remove(text.Text.Length - 1, 1);
                            text.Select(text.Text.Length, 0); 
                        }
                        break;
                    case 3:
                        match = Regex.Match(text.Text, isNumber);
                        if (!match.Success)
                        {
                            text.Text = text.Text.Remove(text.Text.Length - 1);
                            text.Select(text.Text.Length, 0); 
                        }
                        else
                            MessageBox.Show("Success!!!!!");
                        break;
                }
    
            }
