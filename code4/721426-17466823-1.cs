    Regex reg = new Regex(@"^-?\d+[.]?\d*$");
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (!reg.IsMatch(textBox1.Text.Insert(textBox1.SelectionStart, e.KeyChar.ToString()) + "1")) e.Handled = true;
        }
