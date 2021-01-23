    var maxSequence = criticalNotesData
          .GroupBy(n => n.ClientNo)
          .Select(g => new { Client = g.Key, Max = g.Max(i => i.SequenceNo));
    foreach ( var entry in maxSequence )
    {
        Console.WriteLine("Client {0} has max sequence of {1}", 
                          entry.Client, entry.Max); 
    }
