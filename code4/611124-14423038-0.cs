    string line = fileReader.ReadLine();
    while (line != null)
    {
        // Extract the new entry title and date from this line and
        // save them.
        Match entryMatch = entryLineRegex.Match(line);
        GroupCollection matches = entryMatch.Groups;
    
        currentEntryDate = new DateTime(
            Convert.ToInt16(matches["year"].Value),
            Convert.ToInt16(matches["month"].Value),
            Convert.ToInt16(matches["day"].Value)
        );
    
        currentEntryTitle = matches["title"].Value;
    
        while ((line = fileReader.ReadLine()) != null && !line.StartsWith("--"))
        {
            currentEntryText.Append(line);
        }
    
        // Create a JournalEntry with the current entry, then
        // reset for the next entry.
        returnValue.Entries.Add(
            new JournalEntry(
                currentEntryText.ToString(), currentEntryDate
            )
        );
    
        currentEntryText.Clear();
    }
