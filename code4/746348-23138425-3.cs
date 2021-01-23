    public static IEnumerable<String> Split(this String me,int SIZE) {
      //Works by mapping the character index to a 'modulo Staircase'
      //and then grouping by that 'stair step' value
      return me.Select((c, i) => new {
        step = i - i % SIZE,
        letter = c.ToString()
      })
      .GroupBy(kvp => kvp.step)
      .Select(grouping => grouping
        .Select(g => g.letter)
        .Aggregate((a, b) => a + b)
      );
    }
