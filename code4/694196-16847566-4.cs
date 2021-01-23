    public static bool IsValid(IEnumerable<string> requirementNames,
                   IList<int> requirementCounts,
                   IEnumerable<string> candidateNames,
                   IList<int> candidateCounts)
    {
        var requirements = requirementNames
            .Select((x, i) => new
                          {
                              Name = x,
                              Count = requirementCounts[i]
                          })
            .ToList();
        var candidates = candidateNames
            .Select((x, i) => new
                          {
                              Name = x,
                              Count = candidateCounts[i]
                          })
            .ToList();
        var zeroRequirements = requirements
            .Where(x => x.Count == 0)
            .Select(x => x.Name)
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());
        var zeroCandidates = candidates
            .Where(x => x.Count == 0)
            .Select(x => x.Name)
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());
        if (zeroRequirements.Keys.Any(x => !zeroCandidates.ContainsKey(x) ||
                           zeroCandidates[x] < zeroRequirements[x]))
        {
            return false;
        }
        var nonZeroRequirements = requirements
            .Where(x => x.Count != 0)
            .GroupBy(x => x.Name)
            .ToDictionary(x => x.Key, x => x.Select(y => y.Count)
                            .GroupBy(y => y)
                            .ToDictionary(y => y.Key, y => y.Count()));
        var nonZeroCandidates = candidates
            .Where(x => x.Count != 0)
            .GroupBy(x => x.Name)
            .ToDictionary(x => x.Key, x => x.Select(y => y.Count)
                            .GroupBy(y => y)
                            .ToDictionary(y => y.Key, y => y.Count()));
        foreach (var nameRequirement in nonZeroRequirements)
        {
            var name = nameRequirement.Key;
            var constraints = nonZeroCandidates[name];
            // eliminate exact matches
            foreach (var nameCountRequirement in nameRequirement.Value)
            {
                int count;
                if (constraints.TryGetValue(nameCountRequirement.Key, out count) &&
                    count > 0)
                {
                    nonZeroRequirements[nameRequirement.Key][nameCountRequirement.Key] -= 1;
                    constraints[nameCountRequirement.Key] -= 1;
                }
            }
            foreach (var nameCountRequirement in nameRequirement.Value
                                        .Where(x => x.Value > 0)
                                        .OrderBy(x => x.Key))
            {
                var sumValues = TryGetSum(nameCountRequirement.Key, constraints);
                if (!sumValues.Any())
                {
                    return false;
                }
                nonZeroRequirements[nameRequirement.Key][nameCountRequirement.Key] -= 1;
                foreach (var count in sumValues)
                {
                    constraints[count] -= 1;
                }
            }
            // todo - look for smallest overflow sums 
            // for the remaining unmatched requirements
        }
        return true;
    }
    private static IList<int> TryGetSum(int sumNeeded, Dictionary<int, int> constraints)
    {
        var countToIndex = constraints
            .Where(x => x.Key < sumNeeded)
            .Select(x => Enumerable.Range(0, x.Value)
                           .Select(i => new KeyValuePair<int, int>(x.Key, i)))
            .SelectMany(x => x)
            .ToList();
        // sum to List of <count,index>
        var sumToElements = (from a in countToIndex
                     from b in countToIndex
                     where a.Key + b.Key <= sumNeeded
                     where a.Key > b.Key || a.Key == b.Key && a.Value < b.Value
                     select new KeyValuePair<int, IList<KeyValuePair<int, int>>>(a.Key + b.Key,
                                                 new[] { a, b }))
            .ToList();
        while (sumToElements.Any())
        {
            var matches = sumToElements
                .Where(x => x.Key == sumNeeded)
                .OrderByDescending(x => x.Value.Count)
                .ToList();
            if (matches.Any())
            {
                return matches.First().Value.Select(x => x.Key).ToList();
            }
            sumToElements = (from a in sumToElements
                     from b in countToIndex
                     where a.Key + b.Key <= sumNeeded
                     where !a.Value.Any(x => x.Key == b.Key && x.Value == b.Value)
                     select new KeyValuePair<int, IList<KeyValuePair<int, int>>>(a.Key + b.Key,
                       a.Value.Concat(new[] { b }).OrderBy(x => x.Key).ThenBy(x => x.Value).ToList()))
                .GroupBy(x => String.Join(",", x.Value.SelectMany(y => y.Key + ">" + y.Value).ToArray()))
                .Select(x => x.First())
                .ToList();
        }
        return new List<int>();
    }
