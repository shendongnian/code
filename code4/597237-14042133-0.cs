    private bool CheckTimeFormat(string value)
    {
      Regex regex = new Regex("^(1[0-2]|0[1-9]):[0-5][0-9]\040(AM|am|PM|pm)$");
      return regex.IsMatch(value);
    }
    
    private void SetInvalidTimeFormatError()
    {
      bool isValidTime = CheckTimeFormat(textBox2.Text);
      if (isValidTime)
      {
        errorProvider1.SetError(textBox2, string.Empty);
      }
      else
      {
        errorProvider1.SetError(textBox2, "invalid format");
      }
    }
