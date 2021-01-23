    public static IEnumerable<Tuple<int, int>> GetUnpairedNumbers(IEnumerable<Tuple<int, int>> existingPairs ) {
        var uniqueNumbers = existingPairs.SelectMany(p => new[] {p.Item1, p.Item2}).Distinct().ToList();
        var isUsed = uniqueNumbers.ToDictionary(n => n, n => uniqueNumbers.Where(inner => n < inner).ToDictionary(inner => inner, inner => false));
            
        foreach(var currentPair in existingPairs) {
            isUsed[currentPair.Item1][currentPair.Item2] = true;
        }
        return isUsed.Keys.SelectMany(n => isUsed[n].Where(kvp => !kvp.Value).Select(kvp => Tuple.Create(n, kvp.Key)));
    }
    public static void Main(string[] args) {
        var unpairedNumbers = GetUnpairedNumbers(new[] { P(1, 2), P(2, 3), P(3, 4) });
    }
    private static Tuple<int, int> P(int a, int b) {
        return Tuple.Create(a, b);
    }
