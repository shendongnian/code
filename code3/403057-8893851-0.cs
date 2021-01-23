    string start = "a b 3 4 5.7";
    string noSpace = start.Replace(" ", "");
    string noDot = noSpace.Replace(".", "");
    string noNumbers = Regex.Replace(noDot, "[0-9]", "");
    Console.WriteLine(start);
    Console.WriteLine(noSpace);
    Console.WriteLine(noDot);
    Console.WriteLine(noNumbers);
