    public static readonly Parser<int> MatchInt = Parse.Number.Select(int.Parse).Token();
    public static readonly Parser<IEnumerable<int>> MatchIntList = 
          from int1 in MatchInt
          from intRest in Parse.WhiteSpace.AtLeastOnce().Then(_ => MatchInt).Many().End()
          select new List<int>() { int1 }.Concat(intRest);
