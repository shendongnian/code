    char[] list = new char[5];
    Regex r = new Regex("[^A-Z]*$");
    string myString = "SOMEString";
    foreach (Match match in r.Matches(myString))
    {
        list = match.Value.ToCharArray();
        break;
    }
    string str = "invalid chars are ";
    foreach (char ch in list)
    {
        str += ch + ", ";
    }
    Console.Write(str);
