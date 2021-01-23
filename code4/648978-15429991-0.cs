    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if(Char.IsNumber(e.KeyChar))
            if(textBox1.Text.Replace(",", "").Replace(".", "").Length >= 5)
                e.Handled = true;
    }
