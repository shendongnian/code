    TextBox tb = new TextBox();
    tb.KeyPress += tb_KeyPress;
    TextBox tb2 = new TextBox();
    tb2.KeyPress += tb_KeyPress;
      void tb_KeyPress(object sender, KeyPressEventArgs e)
      {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != '.')
        {
            e.Handled = true;
        }
        
        // only allow one decimal point
        if (e.KeyChar == '.'
            && (sender as TextBox).Text.IndexOf('.') > -1)
        {
            e.Handled = true;
        }
      }
