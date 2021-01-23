    Parallel.ForEach(
        ids.Select((Item, Index) => new { Item, Index })
            .GroupBy(x => x.Index / 50)
            .Select(g => g.Select(x => x.Item).ToList()),
        list =>
        {
            Console.WriteLine(String.Join(",", list));
            //GetDetails(list)
        }
    );
