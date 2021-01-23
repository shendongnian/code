    using System.Text.RegularExpressions;
    ...
    // Declare the regular expression
    Regex regex = new Regex(
    	@"(?<=\[)[0-9]+(?=\])",
    	RegexOptions.None
    );
    // Use regex to get value
    string number = regex.Match(target).Value;
    // Convert to number (optional)
    int value = int.Parse(number);
