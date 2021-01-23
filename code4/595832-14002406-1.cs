    list.Select(
        item => item.Substring(0, 
            list.Select(
                innerItem => Enumerable.Range(1, innerItem.Length)
                               .Reverse()
                               .First(proposedlength => list.Count(innerInnerItem => innerInnerItem.StartsWith(innerItem.Substring(0, proposedlength))) > 1)
                       )
                .GroupBy(length => length)
                .ToDictionary(grouping => grouping.Key, grouping => grouping.Count())
                .OrderBy(pair => pair.Value)
                .Select(pair => pair.Key)
                .First())
            ).Distinct()
