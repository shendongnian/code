    var input = new List<int> { 1, 5, 6, 7, 8, 9, 34, 14 };
    var N = input.Count   // just for readability, you can use Count in linq query
    var k = 5
    var res = Enumerable.Range(0, (N - 1) / k + 1)
                        .Select(i => i * k)
                        .Select(i => input.GetRange(i, i + k > N ? N - i : k));
