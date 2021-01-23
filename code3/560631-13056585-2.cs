    using System.Text.RegularExpressions;
    ...
    // Declare target
    string target = "55555>>><<[1234]<>>>788";
    // Declare the regular expression
    Regex regex = new Regex(
    	@"(?<=\[)[0-9]+(?=\])",
    	RegexOptions.None
    );
    // Use regex to get value
    string number = regex.Match(target).Value;
    // Convert to number (optional)
    int value = 0;
    int.TryParse(number, out value);
    // Note: value will be 0 if no matches are found.
