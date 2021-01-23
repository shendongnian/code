    foreach (var fname in FilesToProcess.GetConsumingEnumerable())
    {
        // Load file and process it, creating a MusicRecord
        // Then add to output
        lock (listLock)
        {
            ProcessedRecord.Add(newRecord);
        }
    }
