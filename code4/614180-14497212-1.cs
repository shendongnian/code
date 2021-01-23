    private void textBox1_Leave(object sender, EventArgs e)
        {
            GroupBox parent = (((TextBox) sender).Parent as GroupBox);
            int sum = 0;
            foreach (Control control in parent.Controls)
            {
                TextBox textBox = control as TextBox;
                if (textBox != null)
                {
                    string tbContent = (textBox).Text;
                    int tbNumValue;
                    if(int.TryParse(tbContent, out tbNumValue))
                    {
                        sum += tbNumValue;
                    }
                }
            }
            tbResult.Text = sum == 0 ? string.Empty : sum.ToString();
        }
