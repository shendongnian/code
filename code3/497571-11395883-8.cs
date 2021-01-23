    var result = list.Where(sr => to_search.Any(ts => String.Compare(ts, sr.Title, StringComparison.OrdinalIgnoreCase) == 0))
                     .GroupBy(sr => sr.Title.ToLower())
                     .OrderByDescending(g => g.Count());
    var matched = result.SelectMany(m => m);
    var completeList = matched.Concat(list.Except(matched));
    foreach (var element in completeList)
        Debug.WriteLine(String.Format("ID={0},Title={1}", element.ID, element.Title));
