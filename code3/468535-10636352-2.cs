    var r = new Regex("^\\d(\\d|-)*\\d$|^\\d$");
    Console.WriteLine(r.IsMatch("1-2-3"));
    Console.WriteLine(r.IsMatch("1-222-3333"));
    Console.WriteLine(r.IsMatch("123"));
    Console.WriteLine(r.IsMatch("1-2-3-"));
    Console.WriteLine(r.IsMatch("1"));
    Console.WriteLine(r.IsMatch("-11-2-3-"));
