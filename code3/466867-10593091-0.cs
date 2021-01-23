    string [] Samps = {  "CAT",  "EGG",  "A",  "Z",  "AA",  "BB",  "ZZ",  "AAA",  "HHHHH" };
    foreach (var item in Samps)
    {
        string line = item + "\t\t";
        line += Regex.Match(item, @"^([A-Z])\1+$").Success ?
                Regex.Replace(item, @".(?!$)", "Z") :
                item;
        Console.WriteLine(line);
    }
