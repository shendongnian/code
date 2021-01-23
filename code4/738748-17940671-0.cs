    string yourString = ""; // Load your string
    string[] splits = Regex.Split(yourString, "[ \n\t]"); //Split the long string by spaces, \t and \n
    foreach (string str in splits)
    {
        if(Regex.IsMatch(str, "^^@@.*?@@$$")) // Find words starting and ending with @@
        {
            // You may replace either splits values or build a new string according your specification
        }
    }
