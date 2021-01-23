    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar != (char)Keys.Back &&
            e.KeyChar != (char)Keys.Enter &&
            e.KeyChar != (char)Keys.Escape)
        {
            int dotIndex = textBox1.Text.IndexOf('.');
            if (char.IsDigit(e.KeyChar))
            {
                if (dotIndex != -1 &&
                    dotIndex < textBox1.SelectionStart &&
                    textBox1.Text.Substring(dotIndex + 1).Length >= 2)
                {
                    e.Handled = true;
                }
            }
            else
                e.Handled = e.KeyChar != '.' ||
                            dotIndex != -1 ||
                            textBox1.Text.Length == 0 ||
                            textBox1.SelectionStart + 2 < textBox1.Text.Length;
        }
    }
