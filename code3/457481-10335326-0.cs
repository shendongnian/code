    var appearances = demoList.GroupBy(i => i)
        .OrderByDescending(grp => grp.Count())
        .Select(grp => new { Num = grp.Key, Count = grp.Count() });
    if (appearances.Any())
    {
        int highestAppearanceNum = appearances.First().Num;     // 1
        int highestAppearanceCount = appearances.First().Count; // 5
    }
