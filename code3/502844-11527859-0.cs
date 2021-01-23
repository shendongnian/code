    private string formatPhoneNumber(string number) {
        System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex("^\\(?([1-9]\\d{2})\\)?\\D*?([1-9]\\d{2})\\D*?(\\d{4})$");
        Match re = Regex.Match(number, pattern.ToString());
        return "(" + Convert.ToString(re.Groups[1]) + ") " + Convert.ToString(re.Groups[2]) + "-" + Convert.ToString(re.Groups[3]);
    }
