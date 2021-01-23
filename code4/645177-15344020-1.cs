    private static bool IsThisListConsecutive(IEnumerable<DateTime> orderedSlots)
    {
        return orderedSlots.Pair()
            .All(pair => pair.Item1.AddMonths(1).Month == pair.Item2.Month);
    }
