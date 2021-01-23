    for (int i=0; i<7; i++)
    {
        var entries = new List<string>();
        for (int j=0; j<RecordsCount; j++)
        {
            SomeOperation();
            // Log into list
            entries.Add("Operation #" + j + " results: " + bla bla bla);
        }
        // Log all entries to file at once.
        File.AppendAllLines("logFile.txt", entries);
    }
