    using System.Linq;
    using MoreLinq;
    dynamic students = new[] { "Mark", "Bob", "David", "test" };
    dynamic colors = new[] { "Pink", "Red", "Blue" };
    dynamic result = ((IEnumerable<string>)students).AsQueryable()
        .Zip(((IEnumerable<string>)colors).AsQueryable(), (s, c) => s + c)
        .Dump();
