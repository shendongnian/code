    string FullString = "One, Two, Three, Four";
    Regex rx = new Regex(", ");
    List<string> ListOfStrings = new List<string>();
    foreach (string newString in rx.Split(FullString))
    {
         ListOfStrings.Add(newString);
    }
