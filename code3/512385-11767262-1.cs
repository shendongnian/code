    // Split indexes string to integers
    var indexes = strIndexes.Split(',').Select(int.Parse);
    // Read file once
    var lines = File.ReadLines(myFile);
    // Split them (thank you, devundef!)
    var splitLines = lines.Select(line => line.Split('|')).ToArray();
    // Create dictionary index => column array
    var dict = indexes.ToDictionary(
            index => index,
            index => splitLines.Select(splitLine => splitLine[index]).ToArray()
        );
  
