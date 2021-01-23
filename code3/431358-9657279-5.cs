    public static bool ReachesAdditionalSuccs(
                        SortedSet<int> additionalSuccCandidates,
                        SortedSet<int>[] succsAlreadyReachable)
    {
        var remainingSets = succsAlreadyReachable.Where(set => (set.Min <= additionalSuccCandidates.Min
                                                             && set.Max >= additionalSuccCandidates.Min)
                                                             || (set.Min <= additionalSuccCandidates.Max
                                                             && set.Max >= additionalSuccCandidates.Max))
                                                 .ToList();
        return additionalSuccCandidates.Where(x => !remainingSets.Any(set => set.Contains(x)))
                                       .Any();
    }
