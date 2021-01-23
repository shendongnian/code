    private void txtText_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ((txtText.Text.Length > MaxLengthAllowed - 1) && e.KeyChar != 8)
      {
        e.Handled = true;
        Console.Beep(2000, 90);      
      }
    }
