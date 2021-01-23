    string[] myStrings = { "Foobar",
        "Foo@bar!\"§$%&/()",
        "Föobar",
        "fóÓè"
    };
    
    Regex reg = new Regex(@"^[\P{L}\p{IsBasicLatin}]+$");
    
    foreach (string str in myStrings) {
        Match result = reg.Match(str);
        if (result.Success)
            Console.Out.WriteLine("matched ==> " + str);
        else
            Console.Out.WriteLine("failed ==> " + str);
    }
    
    Console.ReadLine();
