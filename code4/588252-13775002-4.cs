    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar != (char)Keys.Back &&
            e.KeyChar != (char)Keys.Enter &&
            e.KeyChar != (char)Keys.Escape)
        {
            bool dotFlag = textBox1.Text.Contains('.');
            if (char.IsDigit(e.KeyChar))
            {
                if (dotFlag && 
                    textBox1.Text.Substring(textBox1.Text.IndexOf('.') + 1).Length >= 2)
                {
                    e.Handled = true;
                }
            }
            else
                e.Handled = e.KeyChar != '.' ||
                            dotFlag ||
                            textBox1.Text.Length == 0;
        }
    }
