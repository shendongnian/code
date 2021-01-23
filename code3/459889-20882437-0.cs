     Regex nonNumericRegex = new Regex(@"\D");
     if (nonNumericRegex.IsMatch(txtEvDistance.Text))
     {
       //Contains non numeric characters.
       return false;
     }
