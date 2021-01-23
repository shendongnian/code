    bool ValidSIN(string SIN)
    { 
       //normalize
       SIN = SIN.Trim();
       //account for different input formats that use - or space as separators
       SIN = SIN.Replace(" ", "").Replace("-","");
       //basic validations
       if (string.IsNullOrEmpty(SIN)) return false;
       if (SIN.Length != 9) return false;
       if (!SIN.All(c => char.IsDigit(c) ) return false;
       //checksum - we already know here that all characters are digits
       int multiplier = 0;
       int sum = 0;
       foreach (int d in SIN.Select(c => (int)c))
       {
          sum += (d * ((multiplier % 2) + 1)).ToString().Select(c => (int)c).Sum();
          multiplier ++;
       }
       return sum % 10 == 0;
    }
