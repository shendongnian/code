    private IEnumerable<string> GetPermutations(string[] row, string delimiter = "|")
    {
        var separator = new[] { ',' };
        var permutations = new List<string>();
        foreach (var cell in row)
        {
            var parts = cell.Split(separator);
            var perms = permutations.ToArray();
            permutations.Clear();
            foreach (var part in parts)
            {
                if (perms.Length == 0)
                {
                    permutations.Add(part);
                    continue;
                }
                foreach (var perm in perms)
                {
                    permutations.Add(string.Concat(perm, delimiter, part));
                }
            }
        }
        return permutations;
    }
