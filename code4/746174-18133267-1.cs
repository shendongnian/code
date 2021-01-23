    string input = "wooooooow happppppppy";
    var matches = Regex.Matches(input, @"(.)\1+");
    for (int i = 0; i < matches.Count; i++)
    {
        Console.WriteLine("\"" + matches[i].Value + "\" is " + matches[i].Length + " characters long.");
        //...
    }
    Console.Read();
