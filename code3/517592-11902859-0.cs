    string str = "[\"string1\",\"string2\",\"string3\",\"string4\",\"string5\",\"string6\",\"string7\",\"string8\",\"string9\",\"string10\"]";
    Regex rgx = new Regex("[\\[\\]\"]"); // get rid of the quotes and braces
    str = rgx.Replace(str,""); 
    string [] split = str.Split(','); // split on commas. that's it.
    foreach (string s in split)
    {
        Console.WriteLine(s);
    }
