    private static bool IsThisListConsecutive(IEnumerable<DateTime> orderedSlots)
    {
        return orderedSlots.Pair()
            .All(pair => AreSameMonth(pair.Item1.AddMonths(1), pair.Item2));
    }
