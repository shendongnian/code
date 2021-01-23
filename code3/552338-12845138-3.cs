               // Turn the file into an Enumerable of lines
    var dict = File.ReadLines("path/to/file")
               // For each line, turn it into an array of comma-separated values
               .Select(line => line.Split(','))
               // Group the lines together by their first token (the key)
               // The values of the groupings will be the "tokenized" lines
               .GroupBy(line => line[0])
               // Create a dictionary from the collection of lines, 
               // using the Key from the grouping (the first token)
               .ToDictionary(group => group.Key,
                             // Set the values of each entry to the arrays
                             // of tokens found for each key (merging 
                             // them together if a key was found multiple times)
                             group => group.SelectMany(values => 
                                      // ...ignoring the first token and filtering
                                      // out duplicate values
                                      values.Skip(1).Distinct().ToList()));
    return dict;
