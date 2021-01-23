            private void textBox1_KeyDown(object sender, KeyEventArgs e)
            {
                TextBox t = (TextBox)sender;
                if (e.KeyCode == Keys.Back)
                {
                    int carretIndex = t.SelectionStart;
                    if (carretIndex>0 && carretIndex == t.Text.Length && t.Text[carretIndex-1] == ' ')
                    {
                        int lastWordIndex = t.Text.Substring(0, t.Text.Length - 1).LastIndexOf(' ');
                        if (lastWordIndex >= 0)
                        {
                            t.Text = t.Text.Remove(lastWordIndex + 1);
                            t.Select(t.Text.Length, 0);
                        }
                        else
                        {
                            t.Text = string.Empty;
                        }
                    }
                }
            }
