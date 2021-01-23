    var maxSequence = criticalNotesData
          .GroupBy(n => n.ClientNo)
          .Select(g => new { Client = g.Key, Max = g.Max(i => i.SequenceNo) } );
    foreach ( var entry in maxSequence )
    {
        Console.WriteLine("Client {0} has max sequence of {1}", 
                          entry.Client, entry.Max); 
    }
    // Looking at your original, you now want only to know the (from the original)
    // the entries matching MAX.  Since you now know the max per client, a second
    // operation is needed.
    var maxValueEntries = criticalNotesData
            .Where(n => maxSequence
                          .Single(c => c.Client == n.Client)
                          .Max == n.SequenceNo));
