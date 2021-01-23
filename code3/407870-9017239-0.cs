    private void Textbox1_KeyPress(object sender, KeyPressEventArgs e)
    {
       if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
       e.Handled = true;
    }
    private void textbox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (char.IsNumber(e.KeyChar))
        {
            if (Regex.IsMatch(txtStockBought.Text, "\\D+"))
            {
                e.Handled = true;
            }
        }
        else
        {
            e.Handled = e.KeyChar != (char)Keys.Back;
        }
    }
