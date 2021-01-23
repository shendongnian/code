    string s = "/store/457987680928164?id=2";
    string numericInput = string.Empty;
    foreach(char c in s)
    {
       if (char.IsDigit(c))
           numericInput  += c;
    }
