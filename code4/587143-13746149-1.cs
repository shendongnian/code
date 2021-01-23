    static int[] IncorrectLines(string filename)
    {
        // Parse the file into an array of ints, 10* each version number.
        var ints =  File.ReadLines(filename)
            .Select(s => (int)(10 * decimal.Parse(s))).ToArray();
        // Pair each number up with the previous one.
        var pairs = ints
            .Zip(ints.Skip(1), (p, c) => new { Current = c, Previous = p });
        // Include the line numbers
        var withLineNos = pairs
            .Select((pair, index) => new { Pair = pair, LineNo = index + 2 });
        // Only keep incorrect lines
        var incorrect = withLineNos.Where(o => ! (         // not one of either:
                o.Pair.Current - 1 == o.Pair.Previous ||   // simple increment
                (o.Pair.Current % 10 == 0 &&               // major increment
                 (o.Pair.Current / 10) - 1 == o.Pair.Previous / 10)
            ));
        return incorrect.Select(o => o.LineNo).ToArray();
    }
