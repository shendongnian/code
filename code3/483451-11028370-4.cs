    using System.Linq;
    ...
    List<string[]> diff =
        listA.Where(a => !listB.Any(a.SequenceEqual)).Union(
        listB.Where(b => !listA.Any(b.SequenceEqual))).ToList();
