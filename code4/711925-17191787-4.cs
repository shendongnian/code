    String mystring = "1453400e0000875";
    Dictionary<char, string> pairs = new Dictionary<char, string>();
    pairs.Add('a', "09001");
    pairs.Add('b', "09002");
    pairs.Add('c', "09003");
    pairs.Add('d', "09004");
    pairs.Add('e', "09005");
    //...
    char letter = mystring.FirstOrDefault(a => Char.IsLetter(a));
    if (letter != '\0')
    {
          int index = mystring.IndexOf(letter);
          string substitute;
          pairs.TryGetValue(mystring[index], out substitute);
          mystring = mystring.Substring(0, index) + substitute + mystring.Substring(index + 1);
    }
 
