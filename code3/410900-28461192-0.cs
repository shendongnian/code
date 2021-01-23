    // C#
    Enumerable.Range(1, 100)
    .Aggregate(new List<int>{0},
      (acc, x) => { acc.Add(acc.Last() + x); return acc; })
    .Dump(); // Dump using LINQPad; ans: 5050
