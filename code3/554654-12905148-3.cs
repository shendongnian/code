    using System.Text.RegularExpressions;
    ... 
    if (!Regex.IsMatch(password, "[A-Z]")) {
      errorMessage = "Your password must contain at least one uppercase character."; 
    } else if (!Regex.IsMatch(passord, "[a-z]") {
      errorMessage = "Your password must contain at least one lowercase character."; 
    } else if (! Regex.IsMatch(password, @"[\d]")){
      errorMessage = "Your password must contain at least one numerical character."; 
    }
    ...
