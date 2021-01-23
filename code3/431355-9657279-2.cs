    public static bool ReachesAdditionalSuccs(
                        ISet<int> additionalSuccCandidates,
                        ISet<int>[] succsAlreadyReachable)
    {
        return additionalSuccCandidates.Where(x => !succsAlreadyReachable.Any(set => set.Contains(x)))
                                       .Any();
    }
