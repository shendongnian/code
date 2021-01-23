    string sample2 = "My name is {0}, I am living in {1} ..."; 
    var parms = new ArrayList();
    parms.Add("John");
    parms.Add("LA");
    Console.WriteLine(string.Format(sample2, parms.ToArray()));
