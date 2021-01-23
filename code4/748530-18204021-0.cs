    var input = new List<int> { 1, 5, 6, 7, 8, 9, 34, 14 };
    var N = input.Count   // just for readability, you can use Count in linq query
    var res = Enumerable.Range(0, (N - 1) / 5 + 1)
                        .Select(i => i * 5)
                        .Select(i => input.GetRange(i, i + 5 > N ? N - i : 5));
