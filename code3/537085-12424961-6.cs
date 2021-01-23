    public static IEnumerable<IEnumerable<Line>> Group(IEnumerable<Line> horizontalLines, IEnumerable<Line> verticalLines)
    {
      // Clean the input lists here. I'll leave the implementation up to you.
    
      var ungroupedHorizontalLines = new HashSet<Line>(horizontalLines);
      var ungroupedVerticalLines = new HashSet<Line>(verticalLines);
      var groupedLines = new List<List<Line>>();
    
      while (ungroupedHorizontalLines.Count + ungroupedVerticalLines.Count > 0)
      {
        var group = new List<Line>();
        var unprocessedHorizontalLines = new HashSet<Line>();
        var unprocessedVerticalLines = new HashSet<Line>();
   
        if (ungroupedHorizontalLines.Count > 0)
        {
          unprocessedHorizontalLines.Add(ungroupedHorizontalLines.TakeFirst());
        }
        else
        {
          unprocessedVerticalLines.Add(ungroupedVerticalLines.TakeFirst());
        }
    
        while (unprocessedHorizontalLines.Count + unprocessedVerticalLines.Count > 0)
        {
          while (unprocessedHorizontalLines.Count > 0)
          {
            var line = unprocessedHorizontalLines.TakeFirst();
            group.Add(line);
                    unprocessedVerticalLines.AddRange(ungroupedVerticalLines.TakeIntersectingLines(line));
          }
          while (unprocessedVerticalLines.Count > 0)
          {
            var line = unprocessedVerticalLines.TakeFirst();
            group.Add(line);
            unprocessedHorizontalLines.AddRange(ungroupedHorizontalLines.TakeIntersectingLines(line));
          }
        }
        groupedLines.Add(group);
      }
    
      return groupedLines;
    }
