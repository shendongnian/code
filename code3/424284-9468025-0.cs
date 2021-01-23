    string isVisa = "^4[0-9]{12}(?:[0-9]{3})?$";
    string ccnumber = "1234-1234-1234-1234";
    
    if (System.Text.RegularExpressions.Regex.IsMatch(ccnumber, isVisa)) {
      // valid Visa card
    }
