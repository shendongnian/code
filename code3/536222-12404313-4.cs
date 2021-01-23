    // Turning the original into a Dictionary of clientNo returning the 
    // max sequence.
    var maxSequence2 = criticalNotesData
          .GroupBy(n => n.ClientNo)
          .Select(g => new { Client = g.Key, Max = g.Max(i => i.SequenceNo) } )
          .ToDictionary(c => c.Client, c => c.Max);
    var maxValueEntries2 = criticalNotesData
            .Where(n => maxSequence2[n.Client] == n.SequenceNo));
