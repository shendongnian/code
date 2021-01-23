    using System.Linq;
    using MoreLinq;
    var students = new[] { "Mark", "Bob", "David", "test" };
    var colors = new[] { "Pink", "Red", "Blue" };
    var result = ((IEnumerable<string>)students).AsQueryable()
        .Zip(((IEnumerable<string>)colors).AsQueryable(), (s, c) => s + c)
        .Dump();
