    static IQueryable<Stat> ErrorFilter(IQueryable<Stat> source, bool[] WarnLevel) {
        // extract the enabled indices (match to values)
        int[] levels = WarnLevel.Select((val, index) => new { val, index })
                                .Where(pair => pair.val)
                                .Select(pair => pair.index).ToArray();
        switch(levels.Length)
        {
            case 0:
                return source.Where(x => false);
            case 1:
                int level = levels[0];
                return source.Where(x => x.WarnLevel == level);
            case 2:
                int level0 = levels[0], level1 = levels[1];
                return source.Where(
                      x => x.WarnLevel == level0 || x.WarnLevel == level1);
            default:
                return source.Where(x => levels.Contains(x.WarnLevel));
        }
    }
