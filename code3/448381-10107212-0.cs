    var A = new SortedDictionary<decimal,long>();
    var B = new SortedDictionary<decimal,long>();
    A.Add(1, 11);
    A.Add(2, 22);
    A.Add(3, 33);
    B.Add(2, 222);
    B.Add(3, 333);
    B.Add(4, 444);
    var C = A.Concat(B).Aggregate(
        new SortedDictionary<decimal, List<long>>(),
        (result, pair) => {
            List<long> val;
            if (result.TryGetValue(pair.Key, out val))
                val.Add(pair.Value);
            else
                result.Add(pair.Key, new[] { pair.Value }.ToList());
            return result;
        }
    );
    foreach (var x in C)
        Console.WriteLine(
            string.Format(
                "{0}:\t{1}",
                x.Key,
                string.Join(", ", x.Value)
            )
        );
