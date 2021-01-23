    private void textBox1_KeyPress(object sender, KeyEventArgs e)
    {
      if (Char.IsLetter(e.KeyChar))
      {
        // The character is a letter
      }
      else if (Char.IsDigit(e.KeyChar))
      {
        // The character is a digit
      }
      else
      {
        // The character is a special character
      }
    }
