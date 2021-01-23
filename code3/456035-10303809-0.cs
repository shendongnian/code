    string[] outputs = {
                            "this is output",
                            "this is also output",
                            "output",
                            "my output"
                        };
    // order outputs in descending order by length
    var orderedOutputs = outputs.OrderByDescending(s => s.Length);
    // get longest output and add 5 chars
    var padWidth = orderedOutputs.First().Length + 5;
            
    foreach (string str in outputs)
    {
        // this will pad the right side of the string with whitespace when needed
        string paddedString = str.PadRight(padWidth);
        Console.WriteLine("{0}{1}", paddedString, "text");
    }
