    List<object[]> newList = olst
        /* Group the list by the element at position 0 in each item */
        .GroupBy(o => o[0].ToString())
        /* Project the created grouping into a new object[]: */
        .Select(i => new object[]
        {
            i.Key,
            i.Sum(x => (int)x[1])
        })
        .ToList();
