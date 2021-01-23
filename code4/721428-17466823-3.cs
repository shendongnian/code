        Regex reg = new Regex(@"^-?\d+[.]?\d*$");
        bool textChangedByKey;
        string lastText;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (!reg.IsMatch(textBox1.Text.Insert(textBox1.SelectionStart, e.KeyChar.ToString()) + "1"))
            {
                e.Handled = true;
                return;
            }
            textChangedByKey = true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {            
            if (!textChangedByKey)
            {
                if (!reg.IsMatch(textBox1.Text))
                {
                    textBox1.Text = lastText;
                    return;
                }                
            }
            else textChangedByKey = false;
            lastText = textBox1.Text;
        }
