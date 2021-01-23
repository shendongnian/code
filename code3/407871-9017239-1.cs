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
    public class NumericTextBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            e.Handled = true;
            base.OnKeyPress(e);
        }
    }
    public void addTextBox(int number)
        {
            for (int i = 0; i < number; i++)
            {
                string name = "tb_" + (i + 1).ToString("00");
                tb = new NumericTextBox();
                tb.Name = name;
                tb.Location = new Point(x, y);
                tb.Width = 20;
                x += 30;
    
                this.Controls.Add(tb);  
            }
        }
