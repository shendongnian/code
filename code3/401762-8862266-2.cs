    string input = "hello";
    StringBuilder output = new StringBuilder();
    foreach(char c in input)
    {
       output.Append((c - 'a' + 1));
    }
    Console.WriteLine(output);
