    string myString = "full1\nfull2s"; // Strings
    List<string> listOfStrings = new List<string>(); // List of strings
    listOfStrings.Add(myString);
    Regex regex = new Regex(@"full[0-9]+"); // Pattern to look for
    StringBuilder sb = new StringBuilder();
    foreach(string str in listOfStrings) {
    	foreach(Match match in regex.Matches(str)) { // Match patterns
    		sb.AppendLine(match.Value);
    	}
    }
    MessageBox.Show(sb.ToString());
