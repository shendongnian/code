    if !(Char.IsControl(e.KeyChar) || Char.IsDigit(e.KeyChar) || (e.KeyChar == Keys.Decimal && !(TextBox1.Text.Contains("."))))
       {
           e.Handled = true;
       }
   }
