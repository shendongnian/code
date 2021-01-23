    public static IEnumerable<List<Item>> GroupConsecutive(IEnumerable<Item> items)
    {
        if (items.Any())
        {
            string firstType = items.Select(i => i.Type).First();
            var adjacents = items.TakeWhile(i => i.Type == firstType).ToList();
            yield return adjacents;
            foreach (var group in GroupConsecutive(items.Skip(adjacents.Count)))
            {
                yield return group;
            }
        }
    }
