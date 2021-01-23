    // Obvious from the above
    .GroupBy(v => v.Start + v.Length)
    // We want to keep the longest subsequence. Since Start + Length is constant for
    // all, it follows the one with the largest Length has the smallest Start:
    .Select(g => g.OrderBy(u => u.Start).First())
    // We now have an object like { Word = "the", Start = 0, Length = 3 }
    // Convert this to new int[] { 0, 1, 2 }:
    .Select(w => Enumerable.Range(w.Start, w.Length).ToArray())
