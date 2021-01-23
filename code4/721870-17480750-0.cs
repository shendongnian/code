    const string f = "C:/Users.txt";
    string file = System.IO.File.ReadAllText(f);
    
    string[] strings = Regex.Split(file.TrimEnd(), @"\r\n");
    foreach (String str in strings)
    {
        // Do something with the string. Each string comes in one at a time.
        // So this will be run like for but is simple, and easy for one object.
        // str = the string of the line.
        // I shall let you learn the rest it is fairly easy. here is one tip
        lines.Add(str);
    }
    // So something with lines list
