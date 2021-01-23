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
            .ToDictionary(x => x.Key,
                          x => x.Select(y => y.Count)
                                   .GroupBy(y => y)
                                   .ToDictionary(y => y.Key, y => y.Count()));
        var nonZeroCandidates = candidates
            .Where(x => x.Count != 0)
            .GroupBy(x => x.Name)
            .ToDictionary(x => x.Key,
                          x => x.Select(y => y.Count)
                                   .GroupBy(y => y)
                                   .ToDictionary(y => y.Key, y => y.Count()));
        foreach (var name in nonZeroRequirements.Keys.ToList())
        {
            var requirementsForName = nonZeroRequirements[name];
            Dictionary<int, int> candidatesForName;
            if (!nonZeroCandidates.TryGetValue(name, out candidatesForName))
            {
                return false;
            }
            if (candidatesForName.Sum(x => x.Value) <
                requirementsForName.Sum(x => x.Value))
            {
                return false;
            }
            if (candidatesForName.Sum(x => x.Value*x.Key) <
                requirementsForName.Sum(x => x.Value*x.Key))
            {
                return false;
            }
            EliminateExactMatches(candidatesForName, requirementsForName);
            EliminateHighRequirementsWithAvailableHigherCandidate(candidatesForName, requirementsForName);
            EliminateRequirementsThatHaveAMatchingCandidateSum(candidatesForName, requirementsForName);
            if (requirementsForName
                .Any(x => x.Value > 0))
            {
                return false;
            }
        }
        return true;
    }
    private static void EliminateRequirementsThatHaveAMatchingCandidateSum(
        IDictionary<int, int> candidatesForName,
        IDictionary<int, int> requirementsForName)
    {
        var requirements = requirementsForName
            .Where(x => x.Value > 0)
            .OrderByDescending(x => x.Key)
            .SelectMany(x => Enumerable.Repeat(x.Key, x.Value))
            .ToList();
        if (!requirements.Any())
        {
            return;
        }
        // requirements -> candidates used
        var items = GenerateCandidateSetsThatSumToOrOverflow(
            requirements.First(),
            candidatesForName,
            new List<int>())
            .Concat(new[] {new KeyValuePair<int, IList<int>>(0, new List<int>())})
            .Select(x => new KeyValuePair<IList<int>, IList<int>>(
                             new[] {x.Key}, x.Value));
        foreach (var count in requirements.Skip(1))
        {
            var count1 = count;
            items = (from i in items
                     from o in GenerateCandidateSetsThatSumToOrOverflow(
                         count1,
                         candidatesForName,
                         i.Value)
                     select
                         new KeyValuePair<IList<int>, IList<int>>(
                         i.Key.Concat(new[] {o.Key}).OrderBy(x => x).ToList(),
                         i.Value.Concat(o.Value).OrderBy(x => x).ToList()))
                .GroupBy(
                    x => String.Join(",", x.Key.Select(y => y.ToString()).ToArray()) + ">"
                         + String.Join(",", x.Value.Select(y => y.ToString()).ToArray()))
                .Select(x => x.First());
        }
        var bestSet = items
            .OrderByDescending(x => x.Key.Count(y => y > 0)) // match the most requirements
            .ThenByDescending(x => x.Value.Count) // use the most candidates
            .ToList();
        var best = bestSet.First();
        foreach (var requirementCount in best.Key.Where(x => x > 0))
        {
            requirementsForName[requirementCount] -= 1;
        }
        foreach (var candidateCount in best.Value.Where(x => x > 0))
        {
            candidatesForName[candidateCount] -= 1;
        }
    }
    private static void EliminateHighRequirementsWithAvailableHigherCandidate(
        IDictionary<int, int> candidatesForName,
        IDictionary<int, int> requirementsForName)
    {
        foreach (var count in requirementsForName
            .Where(x => x.Value > 0)
            .OrderByDescending(x => x.Key)
            .Select(x => x.Key)
            .ToList())
        {
            while (requirementsForName[count] > 0)
            {
                var count1 = count;
                var largerCandidates = candidatesForName
                    .Where(x => x.Key > count1)
                    .OrderByDescending(x => x.Key)
                    .ToList();
                if (!largerCandidates.Any())
                {
                    return;
                }
                var largerCount = largerCandidates.First().Key;
                requirementsForName[count] -= 1;
                candidatesForName[largerCount] -= 1;
            }
        }
    }
    private static void EliminateExactMatches(
        IDictionary<int, int> candidatesForName,
        IDictionary<int, int> requirementsForName)
    {
        foreach (var count in requirementsForName.Keys.ToList())
        {
            int numberOfCount;
            if (candidatesForName.TryGetValue(count, out numberOfCount) &&
                numberOfCount > 0)
            {
                var toRemove = Math.Min(numberOfCount, requirementsForName[count]);
                requirementsForName[count] -= toRemove;
                candidatesForName[count] -= toRemove;
            }
        }
    }
    private static IEnumerable<KeyValuePair<int, IList<int>>> GenerateCandidateSetsThatSumToOrOverflow(
        int sumNeeded,
        IEnumerable<KeyValuePair<int, int>> candidates,
        IEnumerable<int> usedCandidates)
    {
        var usedCandidateLookup = usedCandidates
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());
        var countToIndex = candidates
            .Select(x => Enumerable.Range(
                0,
                usedCandidateLookup.ContainsKey(x.Key)
                    ? x.Value - usedCandidateLookup[x.Key]
                    : x.Value)
                             .Select(i => new KeyValuePair<int, int>(x.Key, i)))
            .SelectMany(x => x)
            .ToList();
        // sum to List of <count,index>
        var sumToElements = countToIndex
            .Select(a => new KeyValuePair<int, IList<KeyValuePair<int, int>>>(
                             a.Key, new[] {a}))
            .ToList();
        countToIndex = countToIndex.Where(x => x.Key < sumNeeded).ToList();
        while (sumToElements.Any())
        {
            foreach (var set in sumToElements
                .Where(x => x.Key >= sumNeeded))
            {
                yield return new KeyValuePair<int, IList<int>>(
                    sumNeeded,
                    set.Value.Select(x => x.Key).ToList());
            }
            sumToElements = (from a in sumToElements.Where(x => x.Key < sumNeeded)
                             from b in countToIndex
                             where !a.Value.Any(x => x.Key == b.Key && x.Value == b.Value)
                             select new KeyValuePair<int, IList<KeyValuePair<int, int>>>(
                                 a.Key + b.Key,
                                 a.Value.Concat(new[] {b})
                                     .OrderBy(x => x.Key)
                                     .ThenBy(x => x.Value)
                                     .ToList()))
                .GroupBy(x => String.Join(",", x.Value.Select(y => y.Key.ToString()).ToArray()))
                .Select(x => x.First())
                .ToList();
        }
    }
    private static IEnumerable<int> GetAddendsFor(int sum, Random random)
    {
        var values = new List<int>();
        while (sum > 0)
        {
            var addend = random.Next(1, sum);
            sum -= addend;
            values.Add(addend);
        }
        return values;
    }
