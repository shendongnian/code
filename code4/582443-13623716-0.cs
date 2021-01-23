    while ((line = reader.ReadLine()) != null)
    {
        var beginning = line.Substring(0, 3);
        if(beginning != "100" && beginning != "200" && beginning != "300")
            continue;
        list.Add(line); // Add to list.
        Console.WriteLine(line); // Write to console.
    }
