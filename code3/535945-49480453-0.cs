      private void buttonDel_Click(object sender, EventArgs e)
            {
                   if (sender == buttonDel)
                {
                    s = textBox1.Text;
    
                    if (s.Length > 1)
                    {
                        s = s.Substring(0,s.Length - 1);
                        textBox1.Text = s;
                    }
                    else
                    {
                        textBox1.Text = "0";
                    }
                }
            }
