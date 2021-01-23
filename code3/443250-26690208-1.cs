    string senderText = (sender as TextBox).Text;
    string senderName = (sender as TextBox).Name;
    string[] splitByDecimal = senderText.Split('.');
    int cursorPosition = (sender as TextBox).SelectionStart;
    if (!char.IsControl(e.KeyChar) 
        && !char.IsDigit(e.KeyChar) 
        && (e.KeyChar != '.'))
    {
        e.Handled = true;
    }
    if (e.KeyChar == '.' 
        && senderText.IndexOf('.') > -1 )
    {
        e.Handled = true;
    }
    if (!char.IsControl(e.KeyChar) 
        && senderText.IndexOf('.') < cursorPosition 
        && splitByDecimal.Length > 1 
        && splitByDecimal[1].Length == 2)
    {
        e.Handled = true;
    }
