    String mystring = "1453a400e0000b875";
    Dictionary<char, string> pairs = new Dictionary<char, string>();
    pairs.Add('a', "09001");
    pairs.Add('b', "09002");
    pairs.Add('c', "09003");
    pairs.Add('d', "09004");
    pairs.Add('e', "09005");
    //...
    var lettersList = mystring.Where(a => Char.IsLetter(a));
    foreach (char letter in lettersList)
    {
            int index = mystring.IndexOf(letter);
            string substitute;
            pairs.TryGetValue(mystring[index], out substitute);
            mystring = mystring.Substring(0, index) + substitute + mystring.Substring(index + 1);
    }
