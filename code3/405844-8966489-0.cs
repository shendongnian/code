    using System.Text.RegularExpressions;
    string GoodParts(string input) {
      Regex re = new Regex(@"^(.*\D)\d{4}(\D|$)");
      var match = re.Match(input);
      string result = Regex.Replace(match.Groups[1].Value, "[^0-9a-zA-Z]+", "");
      return result;
    }
