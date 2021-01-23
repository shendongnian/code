    int Digits(string input) {
    {
       int count = 0;
       foreach (char c in str)
       {
          if (c > '0' && c < '9')
              count++;
       }
       return count;
    }
    bool IsValid(string input)
    {
        if (Digits(input) <= 8) {
            // is numeric
            return Regex.IsMatch(input, @"[0-9]+");
        }
        else {
            // has alpha && is alpha-numeric
            return Regex.IsMatch(input, @"[a-zA-Z]+") && Regex.IsMatch(input, @"[0-9a-zA-Z]");
        }
    }
        
