    private static IEnumerable<T> Flatten<T>(T[,] data) {
        var r = data.GetLength(0);
        var c = data.GetLength(1);
        return Enumerable.Range(0, r*c).Select(i => data[i/c, i%c]);
    }
    var symTableItems = new HashSet<string>(Flatten(symboltable1));
    var allValid = result.Where(s => symTableItems.Contains(s)).ToList();
