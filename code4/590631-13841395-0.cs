    string str = "8\'5\"";
    Console.WriteLine(str);
    str = str.Replace('\'', '-');
    Console.WriteLine(str);
    str = str.Insert(0, "\"");
    Console.WriteLine(str);
    Console.ReadLine();
    //one row version
    str = str.Replace('\'', '-').Insert(0, "\"");
    Console.WriteLine(str);
    Console.ReadLine();
