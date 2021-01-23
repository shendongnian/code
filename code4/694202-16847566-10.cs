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
        foreach (var name in nonZeroRequirements.Keys.ToList())
        {
            var requirementsForName = nonZeroRequirements[name];
            Dictionary<int, int> constraintsForName;
            if (!nonZeroCandidates.TryGetValue(name, out constraintsForName))
            {
                return false;
            }
            if (constraintsForName.Sum(x => x.Value) <
                requirementsForName.Sum(x => x.Value))
            {
                return false;
            }
            if (constraintsForName.Sum(x => x.Value*x.Key) <
                requirementsForName.Sum(x => x.Value*x.Key))
            {
                return false;
            }
            EliminateExactMatches(constraintsForName, requirementsForName);
            EliminateHighRequirementsWithAvailableHigherConstraint(constraintsForName, requirementsForName);
            EliminateRequirementsThatHaveAMatchingConstraintSum(constraintsForName, requirementsForName);
            foreach (var count in requirementsForName
                .Where(x => x.Value > 0)
                .OrderBy(x => x.Key)
                .Select(x => x.Key)
                .ToList())
            {
                do
                {
                    var sumValues = TryGetOverflowSum(count, constraintsForName);
                    if (!sumValues.Any())
                    {
                        return false;
                    }
                    requirementsForName[count] -= 1;
                    foreach (var countValue in sumValues)
                    {
                        constraintsForName[countValue] -= 1;
                    }
                } while (requirementsForName[count] > 0);
            }
        }
        return true;
    }
    private static void EliminateRequirementsThatHaveAMatchingConstraintSum(Dictionary<int, int> constraintsForName,
                                                                            Dictionary<int, int> requirementsForName)
    {
        foreach (var count in requirementsForName
            .Where(x => x.Value > 0)
            .OrderBy(x => x.Key)
            .Select(x => x.Key)
            .ToList())
        {
            if (constraintsForName.Sum(x => x.Value) <=
                requirementsForName.Sum(x => x.Value))
            {
                // can't risk summing when we only have
                // one candidate available per requirement
                continue;
            }
            do
            {
                var sumValues = TryGetSum(count, constraintsForName, requirementsForName.Sum(x => x.Value));
                if (!sumValues.Any())
                {
                    break;
                }
                requirementsForName[count] -= 1;
                foreach (var countValue in sumValues)
                {
                    constraintsForName[countValue] -= 1;
                }
            } while (requirementsForName[count] > 0);
        }
    }
    private static void EliminateHighRequirementsWithAvailableHigherConstraint(
        Dictionary<int, int> constraintsForName, Dictionary<int, int> requirementsForName)
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
                var largerConstraints = constraintsForName
                    .Where(x => x.Key > count1)
                    .OrderByDescending(x => x.Key)
                    .ToList();
                if (!largerConstraints.Any())
                {
                    return;
                }
                var largerCount = largerConstraints.First().Key;
                requirementsForName[count] -= 1;
                constraintsForName[largerCount] -= 1;
            }
        }
    }
    private static void EliminateExactMatches(Dictionary<int, int> constraintsForName,
                                              Dictionary<int, int> requirementsForName)
    {
        foreach (var count in requirementsForName.Keys.ToList())
        {
            int numberOfCount;
            if (constraintsForName.TryGetValue(count, out numberOfCount) &&
                numberOfCount > 0)
            {
                var toRemove = Math.Min(numberOfCount, requirementsForName[count]);
                requirementsForName[count] -= toRemove;
                constraintsForName[count] -= toRemove;
            }
        }
    }
    private static IEnumerable<int> TryGetOverflowSum(int sumNeeded, Dictionary<int, int> constraints)
    {
        var countToIndex = constraints
            .Select(x => Enumerable.Range(0, x.Value)
                             .Select(i => new KeyValuePair<int, int>(x.Key, i)))
            .SelectMany(x => x)
            .ToList();
        // sum to List of <count,index>
        var sumToElements = (from a in countToIndex
                             select new KeyValuePair<int, IList<KeyValuePair<int, int>>>(
                                 a.Key,
                                 new[] {a}))
            .ToList();
        if (!sumToElements.Any())
        {
            if (countToIndex.Any())
            {
                var onlyPossibleMatch = countToIndex.First().Key;
                if (onlyPossibleMatch > sumNeeded)
                {
                    return new List<int> {onlyPossibleMatch};
                }
            }
            return new List<int>();
        }
        int previousBest;
        var best = sumToElements
            .Where(x => x.Key > sumNeeded)
            .OrderBy(x => x.Key)
            .Select(x => x.Key)
            .Concat(new[] {Int32.MaxValue})
            .First();
        int sumToElementsCount;
        do
        {
            sumToElementsCount = sumToElements.Count;
            previousBest = best;
            var matches = sumToElements
                .Where(x => x.Key == sumNeeded + 1)
                .OrderByDescending(x => x.Value.Count)
                .ToList();
            if (matches.Any())
            {
                return matches.First().Value.Select(x => x.Key).ToList();
            }
            sumToElements = (from a in sumToElements
                             from b in countToIndex
                             where !a.Value.Any(x => x.Key == b.Key && x.Value == b.Value)
                             select new KeyValuePair<int, IList<KeyValuePair<int, int>>>(
                                 a.Key + b.Key,
                                 a.Value.Concat(new[] {b})
                                     .OrderBy(x => x.Key)
                                     .ThenBy(x => x.Value)
                                     .ToList())).Concat(sumToElements)
                .GroupBy(x => String.Join(",", x.Value.Select(y => y.Key + ">" + y.Value).ToArray()))
                .Select(x => x.First())
                .ToList();
            var possibleBest = sumToElements
                .Where(x => x.Key > sumNeeded)
                .OrderBy(x => x.Key)
                .ToList();
            if (possibleBest.Any())
            {
                best = possibleBest.First().Key;
            }
        } while (previousBest > best || sumToElementsCount < sumToElements.Count);
        var finalMatches = sumToElements
            .Where(x => x.Key >= sumNeeded)
            .OrderBy(x => x.Key)
            .ThenByDescending(x => x.Value.Count)
            .ToList();
        if (!finalMatches.Any())
        {
            return new List<int>();
        }
        var bestMatch = finalMatches
            .First().Value
            .Select(x => x.Key)
            .ToList();
        return bestMatch;
    }
    private static IEnumerable<int> TryGetSum(int sumNeeded, Dictionary<int, int> constraints,
                                              int numberOfRequirements)
    {
        var countToIndex = constraints
            .Where(x => x.Key < sumNeeded)
            .Select(x => Enumerable.Range(0, x.Value)
                             .Select(i => new KeyValuePair<int, int>(x.Key, i)))
            .SelectMany(x => x)
            .ToList();
        // sum to List of <count,index>
        var sumToElements = (from a in countToIndex
                             where a.Key <= sumNeeded
                             select new KeyValuePair<int, IList<KeyValuePair<int, int>>>(
                                 a.Key, new[] {a}))
            .ToList();
        var bestMatch = new List<KeyValuePair<int, IList<KeyValuePair<int, int>>>>();
        var numberOfConstraints = constraints.Sum(x => x.Value);
        while (sumToElements.Any())
        {
            var matches = sumToElements
                .Where(x => x.Key == sumNeeded)
                .OrderByDescending(x => x.Value.Count)
                .ToList();
            if (matches.Any())
            {
                var newBest = matches.First();
                if (numberOfConstraints - newBest.Value.Count <= numberOfRequirements - 1)
                {
                    break;
                }
                if (bestMatch.Count == 0)
                {
                    bestMatch.Add(newBest);
                }
                else
                {
                    bestMatch[0] = newBest;
                }
            }
            sumToElements = (from a in sumToElements
                             from b in countToIndex
                             where a.Key + b.Key <= sumNeeded
                             where !a.Value.Any(x => x.Key == b.Key && x.Value == b.Value)
                             select new KeyValuePair<int, IList<KeyValuePair<int, int>>>(
                                 a.Key + b.Key,
                                 a.Value.Concat(new[] {b})
                                     .OrderBy(x => x.Key)
                                     .ThenBy(x => x.Value)
                                     .ToList()))
                .GroupBy(x => String.Join(",", x.Value.Select(y => y.Key + ">" + y.Value).ToArray()))
                .Select(x => x.First())
                .ToList();
        }
        if (bestMatch.Any())
        {
            return bestMatch.First().Value.Select(x => x.Key).ToList();
        }
        return new List<int>();
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
