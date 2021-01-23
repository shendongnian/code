    int mostFrequent = elements.Where(s => s != null)
        .Select(s => {
            int i;
            bool isValid = int.TryParse(s, out i);
            return new { IsValid = isValid, Value = i }
        })
        .Where(v => v.IsValid)
        .GroupBy(i => i.Value)
        .OrderByDescending(grp => grp.Count())
        .First().Key
