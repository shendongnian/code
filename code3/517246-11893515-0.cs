    string Source = "Some Text (1234-567890)";
    string[] Splitted = Regex.Split(Source, @"\(");
    foreach (string Item in Splitted)
    Console.WriteLine(Item.Replace(")",""); //Use replace if you want to remove the closing bracket.
    //Map the values
    string First = Splitted[0];
    string Second = Splitted[1].Replace(")","");
