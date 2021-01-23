    public IEnumerable<IEnumerable<Line>> Group(IEnumerable<Line> horizontalLines, IEnumerable<Line> verticalLines)
    {
      // Clean the input lists here. I'll leave the implementation up to you.
    
      var ungroupedLines = new HashSet<Line>(horizontalLines.Concat(verticalLines));
      var groupedLines = new List<List<Line>>();
    
      while(ungroupedLines.Count > 0)
      {
        var group = new List<Line>();
        var unprocessedLines = new HashSet<Line>();
        unprocessedLines.Add(ungroupedLines.TakeFirst());
    
        while(unprocessedLines.Count > 0)
        {
          var line = unprocessedLines.TakeFirst();
          group.Add(line);
          unprocessedLines.AddRange(ungroupedLines.TakeIntersectingLines(line));
        }
          
        groupedLines.Add(group);
      }
    
      return groupedLines;
    }
    
    public static class GroupingExtensions
    {
      public static T TakeFirst<T>(this HashSet<T> set)
      {
        var item = set.First();
        set.Remove(item);
        return item;
      }
    
      public static IEnumerable<Line> TakeIntersectingLines(this HashSet<Line> lines)
      {
        var intersectedLines = lines.Where(l => l.Intersects(line)).ToList();
        lines.RemoveRange(intersectedLines);
        return lines;
      }
    
      public static void RemoveRange<T>(this HashSet<T> set, IEnumerable<T> itemsToRemove)
      {
        foreach(item in itemsToRemove)
        {
          set.Remove(item);
        }
      }
    
      public static void AddRange<T>(this HashSet<T> set, IEnumerable<T> itemsToAdd)
      {
        foreach(item in itemsToRemove)
        {
          set.Add(item);
        }
      }
    }
    
    Add this method to Line
    
    public bool Intersects(Line other)
    {
      // Whether this line intersects the other line or not.
      // I'll leave the implementation up to you.
    }
