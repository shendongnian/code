    // Validate and assign
    foreach(KeyValuePair<string,string> pair in arguments)
    {
        if(!String.IsNullOrEmpty(pair.Value))
        {
            Console.WriteLine(pair.Value);
        }
    }
