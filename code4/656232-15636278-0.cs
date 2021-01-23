    string pattern = @"(?!^[0-9]*$)(?!^[a-z])(?!^[A-Z]*$)^([a-zA-Z0-9!@_:;+]{6,50})$";
    Boolean meetsRequirements = false;
    meetsRequirements = System.Text.RegularExpressions.Regex.IsMatch(txtPassword.Value, pattern);
    meetsRequirements = System.Text.RegularExpressions.Regex.IsMatch(txtPasswordRepeat.Value, pattern);
    return meetsRequirements;
