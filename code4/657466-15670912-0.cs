    string domainUsername = inputString.Split('\n').Where(z => z.ToLower().Contains(@"\")).FirstOrDefault();
    if (domainUsername != null) {
        Console.WriteLine(domainUsername); // Should spit out the appropriate line.
    } else {
        Console.WriteLine("Domain and username not found!"); // Line not found
    }
    
