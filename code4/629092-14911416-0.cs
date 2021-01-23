    string input = "... your input string ...";
    string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string line in lines)
    {
        // you could use a JSON serializer here to deserialize the line
        // and possibly add it to some result collection
    }
