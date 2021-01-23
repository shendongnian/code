    // 1. Project inner lists to a single list (SelectMany)
    // 2. Use "GroupBy" to aggregate the item's based on order in the lists
    // 3. Strip away any ordering key in the final answer
    var query = myList.SelectMany(
        xl => xl.Select((vv,ii) => new { Idx = ii, Value = vv }))
           .GroupBy(xx => xx.Idx)
           .OrderBy(gg => gg.Key)
           .Select(gg => gg.Select(xx => xx.Value));
