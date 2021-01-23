    private bool AreAllValidNumericChars(string str)
    {
      foreach (char c in str)
      {
        if (c != '.')
        {
          if (!Char.IsNumber(c))
            return false;
        }
      }
      return true;
    }
    
    private void textBoxMs_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
      e.Handled = !AreAllValidNumericChars(e.Text) && isGreaterOrLess(e.Text);
    }
    
    public bool isGreaterOrLess(string text)
    {
      int number = Convert.toInt32(text);
      if(number>0 && number<5)
      {
        return true;
      }
      else
      {
        return false
      }
         
    }
