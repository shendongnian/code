    var input = new List<int> { 1, 5, 6, 7, 8, 9, 34, 14 };
    var k = 5
    var res = Enumerable.Range(0, (input.Count - 1) / k + 1)
                        .Select(i => input.GetRange(i * k, Math.Min(k, input.Count - i * k)))
                        .ToList();
