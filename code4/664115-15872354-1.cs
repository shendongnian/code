    public static IList<Devided> dividedNumbersto5(IEnumerable<int> NumberOfCollection)
    {
        IList<Devided> reminderNumber = NumberOfCollection.ToList().GroupBy(g => g % 5).OrderBy(g => g.Key)
            .Select(g => new Devided { Numbers = g.ToList(), Reminder = g.Key }).ToList();
        return reminderNumber;
    }
