    string input = "hello";
    StringBuilder output = new StringBuilder();
    foreach(char c in input)
    {
        switch(c)
        {
            case 'a': output.Append("1"); break;
            case 'b': output.Append("2"); break;
            // etc.
            case 'z': output.Append("26"); break;
        }             
    }
    Console.WriteLine(output);
