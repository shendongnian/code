    var outputRanges = new List<Range>();
    foreach (var range in inputRanges)
    {
       // Let Range.Touches(Range) define a function that returns true
       // iff the two ranges overlap at all (that is, A.Start and/or A.End
       // is between B.Start and B.End)
       var overlaps = outputRanges.Where(range.Touches).ToList();
       
       // If there are no overlaps, then simply add it to the output
       if (!overlaps.Any())
       {
           outputRanges.Add(range);
       }
       // If there are overlaps, merge them
       else
       {
           outputRanges.RemoveAll(overlaps);
           overlaps.Add(range);
           outputRange.Add(new Range() {
               Start = overlaps.Min(_=>_.Start),
               End = overlaps.Max(_=>_.End)
           });
       }
    }
